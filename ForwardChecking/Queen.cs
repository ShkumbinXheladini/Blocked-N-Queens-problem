using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockedNQueen_FCH
{
    class Queen
    {
        public int Nr; //Numri i mbretereshave
        public int[,] Table; //Tabela e shahut si 2D array

        public Queen(int nr) //Konstruktori i klases Queen
        {
            Nr = nr;
            Table = new int[Nr, Nr]; //Tabela me Nr rreshta dhe Nr kolona
            for (int i = 0; i < Nr; i++)
                for (int j = 0; j < Nr; j++)
                    Table[i, j] = 0; //Tabela ne fillim mbushet e gjitha me zero
            Random BlockedPos = new Random(); //Inicializimi i BlockedPos numer random

            int bp = BlockedPos.Next(2, 6); //Range se sa mund te jene blockedPos

            for (int k = 0; k < bp; k++) //Per aq vlera sa jane marr 'bp' 
            {
                int i = BlockedPos.Next(0, Nr); //Caktimi se ne cilin rresht
                int j = BlockedPos.Next(0, Nr); //dhe ne cilen kolone do vendosen
                Table[i, j] = -1; //vlerat -1 ne vend te vlerave 0 qe jane inicializuar fillimisht
            }
        }

        public bool NextPos(int row, int column)
        {
            int i, j;

            for (i = 0; i < column; i++)  //Rreshti
                if (Table[row, i] == 1)
                    return false;

            for (i = row, j = column; i >= 0 && j >= 0; i--, j--) //DiagonaljaL
                if (Table[i, j] == 1)
                    return false;

            for (i = row, j = column; i < Nr && j >= 0; i++, j--) //DiagonaljaR  
                if (Table[i, j] == 1)
                    return false;
            return true;
        }


        public bool Solution(int c, int Nr)
        {

            if (c == Nr)
                return true; //Nese numri i kolones se zgjedhur = numri i queens ateher eshte gjetur zgjidhja

            for (int i = 0; i < Nr; i++)
            {
                //Implementimi i Forward Checking
                // kontrollojm a guxojm me pozicionu ne rreshtin i kolonen q
                if (NextPos(i, c)) //Nese na lejohet vendosja e queen ketu
                {
                    if (Table[i, c] != -1) //Dhe ketu nuk ka te vendosur -1
                    {
                        Table[i, c] = 1; //Ateher vendos 1 ketu dmth vendos queen
                        if (c < Nr - 1) //Nese nuk jemi ne kolonen e fundit, pra nuk i kemi vendos krejt queens
                        {
                            for (int j = 0; j < Nr; j++)//Ketu rritet numri i rreshtit, pasi te kontrollohen kolonat
                                if (NextPos(j, c + 1)) //Shiko se a mund te vendoset queen ne kolonen e rradhes
                                {
                                    if (Table[j, c] != -1) //Tash nese nuk eshte -1 ajo kolone
                                    {
                                        if (Solution(c + 1, Nr))
                                            return true;
                                    }
                                } //Nese eshte kjo solution atehere, kemi gjetur ku vendoset queen e rradhes
                        }
                        else //Perndryshe kemi arritur ti vendosim queens
                        {
                            Solution(c + 1, Nr);
                            return true;
                        }
                        Table[i, c] = 0; //Override edhe njehere kolonat ku nuk ka 1 dhe -1 me 0
                    }
                }
            }
            return false;
        }
        //Shfaqja e rezultatit ne ekran
        public void Display()
        {
            for (int i = 0; i < Nr; i++)
            {
                for (int j = 0; j < Nr; j++)
                {
                    Console.Write(Table[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}