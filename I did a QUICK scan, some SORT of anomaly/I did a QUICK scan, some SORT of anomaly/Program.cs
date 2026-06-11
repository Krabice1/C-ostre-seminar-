using System;

class Program
{
    static void QuickSort(int[] arr, int mensi, int vetsi)
    {
        if (mensi >= vetsi)
            return;

        int pivot = arr[vetsi];

        int hranice_m = mensi;     // hranice menších
        int hranice_v = vetsi;    // hranice větších
        int i = mensi;

        while (i <= hranice_v)
        {
            if (arr[i] < pivot)
            {
                Swap(arr, i, hranice_m);   // prohození s hranicí menších
                i++;
                hranice_m++;
            }
            else if (arr[i] > pivot)   // prohození s hranicí větších
            {
                Swap(arr, i, hranice_v);
                hranice_v--;
            }
            else    // roven pivotu
            {
                i++;
            }
        }

        QuickSort(arr, mensi, hranice_m - 1);  // rekurye
        QuickSort(arr, hranice_v + 1, vetsi);
    }

    static void Swap(int[] arr, int a, int b) 
    {
        int t = arr[a];
        arr[a] = arr[b];
        arr[b] = t;
    }

    static void Main()
    {
        string[] vstup = Console.ReadLine().Split(' ');  // vstup a jeho dělení
        int[] cisla = new int[vstup.Length];

        for (int i = 0; i < vstup.Length; i++)
        {
            cisla[i] = int.Parse(vstup[i]);
        }

        QuickSort(cisla, 0, cisla.Length - 1);  // volání quicksortu

        Console.WriteLine(string.Join(" ", cisla));
    }
}
// Bonus1: Použitím algoritmu Medians of medians (mediánů z mediánů): Celý seznam se rozděli na skupiny po pěti
// příp. jiný počet, a pro každou skupinu se vypočítá její medián. Poté se z těchto mediánů vypočítá další medián.
// Časová složitost pro výběr pivotu je O(n), a to i v nejhorším případě.

// Bonus2: Medián ze tří částí (Median of three) má mnohem větší šanci najít dobrý pivot, protože tento skoromedián
// má nulovou šanci být největším nebo nejmenším prvkem v seznamu a naopak vysokou šanci být blízko skutečnému mediánu.
// Tímto se značně zvyšuje pravděpodobnost, že quicksort bude mít lepší výkon, a to především pro náhodné nebo téměř
// seřazené vstupy.

// Bonus3: Po rozdělení na levou a pravou část, tak rekurzivně zpracujeme pouze tu menší část, zatímco větší část
// zůstane nezpracovaná. Tím se výrazně snižuje hloubka rekurze a zlepšuje se výkon, zejména pro seznamy s mnoha
// duplicitními hodnotami, kde by tradiční quicksort mohl mít problémy s výkonem kvůli nevyváženému rozdělení.

// Bonus4: Pro seznamy s malým množstvím extrémně vzdálených hodnot. (např. 1, 3, 5, 1000)
