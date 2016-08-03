using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/**
 * Eliana Becerra
 * C.I. 23826547
 * **/

namespace Fausto
{

    class Program
    {


        static void Main(string[] args)
        {
            int conF = 0;
            int conC = 0;
            int con = 0;
            string linea = "";
            juego jg = new juego();
            ArrayList vector_linea = new ArrayList();

            StreamReader arc = new StreamReader("entrada.txt");
            while ((linea = arc.ReadLine()) != null)
            {

                for (int i = 0; i < linea.Length; i++)
                {
                        vector_linea.Add(linea[i]);
                        con++;
                }
                    conC++;
                
             }  arc.Close();


                conF = con / conC;
                jg.tablero(conF, conC, vector_linea, con);
                Console.Read();
                jg.recursivo();


                
        }
        }

    
        class juego
        {
            int [][] MA;
            char [][]M;
            int h = 0;
            public int TF; 
            public int TC;
            public int posX;
            public int posY;
            public int []vectX;
            public int []vectY;
            public int TamC=0;



            public void tablero(int fila, int col, ArrayList vc, int tam)
            {
                TF = fila;
                TC = col;
                vectX= new int[fila*col];
                vectY= new int[fila*col];
                MA = new int[TF][];
                for (int i = 0; i < TF; i++)
                    MA[i] = new int[TC];
                
                M=new char[fila][];
                for (int i = 0; i < fila; i++ )
                     M[i]=new char[col];

                for (int i = 0; i < fila; i++)
                    for (int j = 0; j < col; j++)
                        MA[i][j] = 0;

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        M[i][j] = (vc[j+h].ToString())[0];
                        if(M[i][j]=='.')
                            MA[i][j]=0;
                        if(M[i][j]=='#')
                            MA[i][j]=1;
                        if (M[i][j]=='o')
                            MA[i][j]=2;
                        if (M[i][j] == '*')
                        {
                            MA[i][j] = 3;
                            posX = i;
                            posY = j;
                        }
                     }
                    h+=col;
                }
              
                Console.WriteLine("TABLERO");
                for (int i = 0; i < TF; i++)
                {
                    for (int j = 0; j < TC; j++)
                    {
                        if (MA[i][j] == 0)
                            Console.Write('.');
                        if (MA[i][j] == 1)
                            Console.Write('#');
                        if (MA[i][j] == 2)
                            Console.Write('o');
                        if (MA[i][j] == 3)
                            Console.Write('*');

                    } Console.Write("\n");
                }
                
            }//fin tablero

            public void imprimirM(int posx, int posy)
            {
                Console.Clear();
                Console.WriteLine("TABLERO");
                for (int i = 0; i < TF; i++)
                {
                    for (int j = 0; j < TC; j++)
                    {
                        if(MA[i][j]==0)
                            Console.Write('.');
                        if(MA[i][j]==1)
                            Console.Write('#');
                        if(MA[i][j]==2)
                            Console.Write('o');
                        if(MA[i][j]==3)
                            Console.Write('*');
                    }Console.Write("\n");
                }
               
                Console.Read();
                Console.Clear();
            }

            public void imprimerCam(int tam)
            {
                Console.WriteLine("Salida");
                 Console.WriteLine(TamC);
                Console.WriteLine("posX ,  posY");
                for (int i = 1; i < tam; i++)
                    Console.WriteLine(vectX[i]+","+vectY[i]);
               
                Console.Read();
            }

            public int recursivo()
            {
                int enc=0;
                

                if ((posX - 1 >= 0 && posY >= 0) && (MA[posX - 1][posY] == 0 || MA[posX - 1][posY] == 2)) 
                {//1

                    if (MA[posX - 1][posY] == 2)
                    {
                        MA[posX - 1][posY] = 3;
                        posX = posX - 1;
                        enc = 1;
                        vectX[TamC] = posX;
                        vectY[TamC]= posY;
                        TamC++;
                    }
                    else
                        if (MA[posX - 1][posY] == 0)
                        {
                            MA[posX - 1][posY] = 3;
                            posX = posX - 1;
                            vectX[TamC] = posX;
                            vectY[TamC] = posY;
                            TamC++;
                        }
                }
                else
                {
                    if ((posY < TC && posX + 1 < TF) && (MA[posX + 1][posY] == 0 || MA[posX + 1][posY] == 2))
                    {

                        if (MA[posX + 1][posY] == 2)
                        {
                            MA[posX + 1][posY] = 3;
                            posX = posX + 1;
                            vectX[TamC] = posX;
                            vectY[TamC] = posY;
                            TamC++;
                            enc = 1;
                        }
                        else
                        
                            if (MA[posX + 1][posY] == 0)
                            {
                                MA[posX + 1][posY] = 3;
                                posX = posX + 1;
                                vectX[TamC] = posX;
                                vectY[TamC] = posY;
                                TamC++;
                            }
                            
                    }
                    else
                    {
                        if ((posY - 1 >= 0 && posY - 1 < TC) && (MA[posX][posY - 1] == 0) || MA[posX][posY - 1] ==2)
                        {
                           
                            if (MA[posX][posY - 1] == 2)
                            {
                                MA[posX][posY - 1] = 3;
                                posY = posY - 1;
                                vectX[TamC] = posX;
                                vectY[TamC] = posY;
                                TamC++;
                                enc = 1;
                            }
                            else
                            
                                if (MA[posX][posY - 1] == 0)
                                { 
                                    MA[posX][posY - 1] = 3;
                                    posY = posY - 1;
                                    vectX[TamC] = posX;
                                    vectY[TamC] = posY;
                                    TamC++;
                                }
                                
                        }
                        else
                        {
                            if ((posY + 1 >= 0 && posY + 1 < TC) && (MA[posX][posY + 1] == 0 || MA[posX][posY + 1] ==2))
                            {
                                
                                if (MA[posX][posY + 1] == 2)
                                {
                                    MA[posX][posY + 1] = 3;
                                    posY = posY + 1;
                                    vectX[TamC] = posX;
                                    vectY[TamC] = posY;
                                    TamC++;
                                    enc = 1;
                                }
                                else
                                
                                    if (MA[posX][posY + 1] == 0)
                                    {
                                        MA[posX][posY + 1] = 3;
                                        posY = posY + 1;
                                        vectX[TamC] = posX;
                                        vectY[TamC] = posY;
                                        TamC++;
                                    }
                            }
                        }
                    }
                }
                imprimirM(posX, posY);
                if (enc == 0)
                    recursivo();
                else
                {
                    imprimirM(posX, posY);
                    imprimerCam(TamC);
                    Console.Read();

                }
                        return enc;
            }
        }


    
}