; Wersja 1.0 Autor Piotr Kwiatkowski
;   Funkcja bêdzie zwraca³a operacjê sortowania dla tablicy liczb. Bêdzie ona sortowana algorytmem Bubble Sort.
;   Procedura BubbleSort sortuje tablicê liczb ca³kowitych rosn¹co metod¹ b¹belkow¹.
;   Metoda b¹belkowa porównuje kolejne elementy tablicy i zamienia je miejscami, jeœli s¹ one w niew³aœciwej kolejnoœci,
;   powtarzaj¹c ten proces do momentu, gdy ca³a tablica jest posortowana.

.data
nums  dd 0, 0, 0, 0, 0, 0, 0, 0, 0, 0   ; Zainicjowana tablica zerami
count dd 0                              ; Liczba elementów w tablicy
                                        ; Parametry wejœciowe:
                                        ; rdx - Adres pocz¹tkowy tablicy do posortowania
                                        ; Rejestry i znaczniki (flagi) które ulegaj¹ zmianie po wykonaniu procedury:
                                        ; rbx, rcx, rdx, r9, r10, r11, r14, r15
.code
BubbleSort proc export                  ; Rozpoczêcie definicji procedury BubbleSort z eksportem symbolu

    push rdx                            ; Zachowaj wartoœæ rejestru rdx na stosie
    push rcx                            ; Zachowaj wartoœæ rejestru rcx na stosie
    push rbx                            ; Zachowaj wartoœæ rejestru rbx na stosie
    mov r9, 0                           ; Zeruj rejestr r9
    mov r14, rdx                        ; Skopiuj wartoœæ argumentu funkcji (wskaŸnik do danych) do rejestru r14
    mov r15, 0                          ; Zeruj rejestr r15
    dec r14                             ; Zmniejsz wartoœæ wskazywan¹ przez r14 (pomniejsz o 1, bo r14 zawiera d³ugoœæ danych - 1)

    next:                               
        mov rbx, r14                    ; Skopiuj wartoœæ r14 do rejestru rbx (indeks bie¿¹cej iteracji)
        mov r15, 0                      ; Zeruj r15 (indeks dla porównywanych elementów)

    next_compare:
        mov r10d, [rcx + r15 * 4]       ; Skopiuj wartoœæ r14 do rejestru rbx (indeks bie¿¹cej iteracji)
        mov r11d, [rcx + r15 * 4 + 4]   ; Skopiuj wartoœæ r14 do rejestru rbx (indeks bie¿¹cej iteracji)
        cmp r10d, r11d                  ; Porównaj wartoœci
        jl no_swap                      ; Jeœli pierwsza wartoœæ jest mniejsza, przejdŸ do etykiety no_swap
        mov [rcx + r15 * 4], r11d       ; Zamieñ miejscami wartoœci, jeœli druga wartoœæ jest mniejsza
        mov [rcx + r15 * 4 + 4], r10d

    no_swap:
        inc r15                         ; Zwiêksz indeks r15 (przejœcie do kolejnej pary elementów)
        dec rbx                         ; Zmniejsz licznik iteracji
        jnz next_compare                ; Jeœli rbx nie jest zerem, kontynuuj porównywanie
        dec r14                         ; Zmniejsz licznik iteracji zewnêtrznej
        jnz next                        ; Jeœli r14 nie jest zerem, kontynuuj sortowanie

    

    ; Zakoñcz
    endr:
        pop rbx                         ; Przywróæ wartoœæ rejestru rbx ze stosu
        pop rcx                         ; Przywróæ wartoœæ rejestru rcx ze stosu
        pop rdx                         ; Przywróæ wartoœæ rejestru rdx ze stosu
        ret                             ; Powrót z procedury BubbleSort

BubbleSort endp                         ; Zakoñczenie definicji procedury BubbleSort

END                                     ; Zakoñczenie programu