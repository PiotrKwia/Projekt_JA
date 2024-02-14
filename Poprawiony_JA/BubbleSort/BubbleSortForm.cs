using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace BubbleSort
{
    // Form for Bubble Sort application
    public partial class BubbleSortForm : Form
    {
        
        // Constructor for BubbleSortForm
        public BubbleSortForm()
        {
            InitializeComponent();
        }
        // Enum representing different programming languages
        private enum Language
        {
            Asm,
            Cpp,
            Csh
        }
        // Progress variable to track sorting progress
        private double progress = 0.0;

        // Maximum number of threads for sorting
        private const int maxThreads =500;

        // Importing external function from BubbleSortDLL.dll to perform bubble sort in assembly
        [DllImport("BubbleSortDLL.dll")]
        private static extern void BubbleSort(IntPtr nums, int count);

        // Importing external function from BubbleSortDLL.dll to perform bubble sort in C++
        [DllImport("BubbleSortDLL.dll")]
        private static extern void BubbleSortCpp(IntPtr nums, int count);

        // Method to perform bubble sort in C#
        private void BubbleSortCs(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;
                    }
                }
            }
        }
        // Event handler for form load event
        private void BubbleSortForm_Load(object sender, EventArgs e)
        {
            // Default settings when form loads
            radioButtonAsm.Checked = true;
            textBoxThreads.Text = Environment.ProcessorCount.ToString();
        }
        // Event handler for button click to generate unsorted files
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Validate and generate random unsorted files
            int nums = 0;
            bool result = int.TryParse(textBoxNums.Text.ToString(), out nums);
            if (!result || nums < 2)
            {
                MessageBox.Show($"Numbers should be greater than 1");
                return;
            }

            if (!Directory.Exists("unsorted"))
            {
                Directory.CreateDirectory("unsorted");
            }

            progressBar.Value = 0;
            progress = 0.0;

            Random random = new Random();
            for (int i = 0; i < maxThreads; ++i)
            {
                using (StreamWriter writer = new StreamWriter($"unsorted/{i}.txt"))
                {
                    for (int j = 0; j < nums; j++)
                    {
                        writer.Write($"{random.Next(0, nums)} ");
                    }
                    writer.Close();
                }
                progress += 100.0 / (double)maxThreads;
                progressBar.Value = Math.Min(100, (int)progress);
            }

            MessageBox.Show($"The files were generated to the \"unsorted\" folder");
        }

        // Event handler for button click to start sorting
        private async void buttonSort_Click(object sender, EventArgs e)
        {
            // Sort unsorted files based on selected language
            progress = 0.0;
            progressBar.Value = 0;
            //check if unsorted files exist
            if (!Directory.Exists("unsorted"))
            {
                MessageBox.Show($"Unsorted files weren't generated! Failed to sort");
                return;
            }

            //check threads number
            int threads = 0;
            bool result = int.TryParse(textBoxThreads.Text.ToString(), out threads);
            if (!result || threads < 1 || threads > 500)
            {
                MessageBox.Show($"Threads should be <1, 64>");
                return;
            }

            //load unsorted nums
            List<List<int>> arrays = new List<List<int>>();
            for (int i = 0; i < threads; i++)
            {
                string fileName = $"unsorted/{i}.txt";
                if (!File.Exists(fileName))
                {
                    MessageBox.Show("Pliki wejœciowe nie istniej¹! Najpierw je wygeneruj.");
                    return;
                }
                string[] lines = File.ReadAllLines(fileName);
                string[] nums = lines.SelectMany(line => line.Split(' ')).ToArray();

                List<int> array = new List<int>();
                for (int j = 0; j < nums.Length - 1; ++j)
                {
                    if (int.TryParse(nums[j], out int parsedNumber))
                    {
                        array.Add(parsedNumber);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to load unsorted file. Failed to sort");
                        return;
                    }
                }
                arrays.Add(array);
            }

            if (!Directory.Exists("sorted"))
            {
                Directory.CreateDirectory("sorted");
            }

            if (radioButtonAsm.Checked)
            {
                List<int[]> arraysAsm = arrays.Select(innerList => innerList.ToArray()).ToList();
                await Sort(arraysAsm, Language.Asm, threads);
                MessageBox.Show("Files are sorted succesfully!\nResults saved to sorted/asm");
            }
            else if (radioButtonCpp.Checked)
            {
                List<int[]> arraysCpp = arrays.Select(innerList => innerList.ToArray()).ToList();
                await Sort(arraysCpp, Language.Cpp, threads);
                MessageBox.Show("Files are sorted succesfully!\nResults saved to sorted/cpp");
            }
            else
            {
                List<int[]> arraysCsh = arrays.Select(innerList => innerList.ToArray()).ToList();
                await Sort(arraysCsh, Language.Csh, threads);
                MessageBox.Show("Files are sorted succesfully!\nResults saved to sorted/csh");
            }
        }
        // Asynchronous method to sort arrays using specified language and number of threads
        private async Task Sort(List<int[]> arrays, Language language, int threads)
        {
            // Start stopwatch to measure sorting time
            Stopwatch stopWatch = Stopwatch.StartNew();

            // Parallel sorting of arrays based on selected language
            List<Task> tasks = new List<Task>();
            for (int thread = 0; thread < threads; thread++)
            {
                int threadNr = thread;
                tasks.Add(Task.Run(() =>
                {
                    
                    int[] nums = arrays[threadNr];
                    if (language == Language.Asm)
                    {
                        IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(nums, 0);
                        BubbleSort(ptr, nums.Length);
                    }
                    else if (language == Language.Cpp)
                    {
                        IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(nums, 0);
                        BubbleSortCpp(ptr, nums.Length);
                    }
                    else if (language == Language.Csh)
                    {
                        BubbleSortCs(nums);
                    }
                    // Update progress bar according to sorting progress
                    progress += 100.0 / (double)threads;
                    UpdateProgressBar();
                }));
            }
            // Save sorted arrays to appropriate directory based on language
            await Task.WhenAll(tasks);
            string lang = "asm";
            if (!Directory.Exists($"sorted/{lang}"))
            {
                Directory.CreateDirectory($"sorted/{lang}");
            }

            if (language == Language.Asm)
            {
                lang = "asm";
            }
            else if (language == Language.Cpp)
            {
                lang = "cpp";
            }
            else if (language == Language.Csh)
            {
                lang = "csh";
            }

            for (int i = 0; i < arrays.Count; i++)
            {
                string fileName = $"sorted/{lang}/{i}.txt";
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(string.Join(" ", arrays[i]));
                    writer.Close();
                }
            }

            // Update UI with sorting time for the respective language
            long elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
            if (language == Language.Asm)
            {
                labelAsmTime.Text = elapsedMilliseconds.ToString() + " ms";
            }
            else if (language == Language.Cpp)
            {
                labelCppTime.Text = elapsedMilliseconds.ToString() + " ms";
            }
            else if (language == Language.Csh)
            {
                labelCshTime.Text = elapsedMilliseconds.ToString() + " ms";
            }
        }
        // Method to update progress bar safely across threads
        private void UpdateProgressBar()
        {
            // Update progress bar value safely across threads
            if (progressBar.InvokeRequired)
            {
                Action updateDelegate = new Action(UpdateProgressBar);
                this.Invoke(updateDelegate);
            }
            else
            {
                progressBar.Value = Math.Min(100, (int)progress);
            }
        }
    }
}
