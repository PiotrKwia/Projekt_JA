; Wersja 1.0 Autor Piotr Kwiatkowski
;   Funkcja b�dzie zwraca�a operacj� sortowania dla tablicy liczb. B�dzie ona sortowana algorytmem Bubble Sort.
;   Procedura BubbleSort sortuje tablic� liczb ca�kowitych rosn�co metod� b�belkow�.
;   Metoda b�belkowa por�wnuje kolejne elementy tablicy i zamienia je miejscami, je�li s� one w niew�a�ciwej kolejno�ci,
;   powtarzaj�c ten proces do momentu, gdy ca�a tablica jest posortowana.

.data
nums  dd 0, 0, 0, 0, 0, 0, 0, 0, 0, 0   ; Zainicjowana tablica zerami
count dd 0                              ; Liczba element�w w tablicy
                                        ; Parametry wej�ciowe:
                                        ; rdx - Adres pocz�tkowy tablicy do posortowania
                                        ; Rejestry i znaczniki (flagi) kt�re ulegaj� zmianie po wykonaniu procedury:
                                        ; rbx, rcx, rdx, r9, r10, r11, r14, r15
.code
BubbleSort proc export                  ; Rozpocz�cie definicji procedury BubbleSort z eksportem symbolu

    push rdx                            ; Zachowaj warto�� rejestru rdx na stosie
    push rcx                            ; Zachowaj warto�� rejestru rcx na stosie
    push rbx                            ; Zachowaj warto�� rejestru rbx na stosie
    mov r9, 0                           ; Zeruj rejestr r9
    mov r14, rdx                        ; Skopiuj warto�� argumentu funkcji (wska�nik do danych) do rejestru r14
    mov r15, 0                          ; Zeruj rejestr r15
    dec r14                             ; Zmniejsz warto�� wskazywan� przez r14 (pomniejsz o 1, bo r14 zawiera d�ugo�� danych - 1)

    next:                               
        mov rbx, r14                    ; Skopiuj warto�� r14 do rejestru rbx (indeks bie��cej iteracji)
        mov r15, 0                      ; Zeruj r15 (indeks dla por�wnywanych element�w)

    next_compare:
        mov r10d, [rcx + r15 * 4]       ; Skopiuj warto�� r14 do rejestru rbx (indeks bie��cej iteracji)
        mov r11d, [rcx + r15 * 4 + 4]   ; Skopiuj warto�� r14 do rejestru rbx (indeks bie��cej iteracji)
        cmp r10d, r11d                  ; Por�wnaj warto�ci
        jl no_swap                      ; Je�li pierwsza warto�� jest mniejsza, przejd� do etykiety no_swap
        mov [rcx + r15 * 4], r11d       ; Zamie� miejscami warto�ci, je�li druga warto�� jest mniejsza
        mov [rcx + r15 * 4 + 4], r10d

    no_swap:
        inc r15                         ; Zwi�ksz indeks r15 (przej�cie do kolejnej pary element�w)
        dec rbx                         ; Zmniejsz licznik iteracji
        jnz next_compare                ; Je�li rbx nie jest zerem, kontynuuj por�wnywanie
        dec r14                         ; Zmniejsz licznik iteracji zewn�trznej
        jnz next                        ; Je�li r14 nie jest zerem, kontynuuj sortowanie

    

    ; Zako�cz
    endr:
        pop rbx                         ; Przywr�� warto�� rejestru rbx ze stosu
        pop rcx                         ; Przywr�� warto�� rejestru rcx ze stosu
        pop rdx                         ; Przywr�� warto�� rejestru rdx ze stosu
        ret                             ; Powr�t z procedury BubbleSort

BubbleSort endp                         ; Zako�czenie definicji procedury BubbleSort

END                                     ; Zako�czenie programu