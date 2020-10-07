using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Token
        {
            public string tipo { get; set; }
            public int identificador { get; set; }
            public string lexema { get; set; }
        }

        private void buttonAnalizar_Click(object sender, EventArgs e)
        {
            var tokens = new BindingList<Token>();
            string cadena, lexema, token;
            int i, estado, valor;

            i = 0;
            estado = 0;
            cadena = textBoxAnalisis.Text;

            while(i <= (cadena.Length - 1) && estado == 0)
            {
                lexema = "";
                token = "";
                valor = -1;
                while(i <= (cadena.Length - 1) && estado != -1)
                {
                    if (estado == 0)
                    {
                        if (Char.IsWhiteSpace(cadena, i)) //ignorar espacios
                            estado = 0;
                        else if (Char.IsLetter(cadena, i) || cadena[i] == '_') //empieza id 
                        {
                            estado = 1;
                            lexema += cadena[i];
                            token = "id";
                            valor = 1;
                        }
                        else if (Char.IsDigit(cadena, i)) //empieza constante
                        {
                            estado = 2;
                            lexema += cadena[i];
                            token = "constante";
                            valor = 13;
                        }
                        else if (cadena[i] == ';') //Solo es un caracter por lo que no necesita estado propio
                        {
                            lexema += cadena[i];
                            token = ";";
                            valor = 2;
                            estado = -1;
                        }
                        else if (cadena[i] == ',') //Solo es un caracter por lo que no necesita estado propio
                        {
                            lexema += cadena[i];
                            token = ",";
                            valor = 3;
                            estado = -1;
                        }
                        else if (cadena[i] == '(') //Solo es un caracter por lo que no necesita estado propio
                        {
                            lexema += cadena[i];
                            token = "(";
                            valor = 4;
                            estado = -1;
                        }
                        else if (cadena[i] == ')') //Solo es un caracter por lo que no necesita estado propio
                        {
                            lexema += cadena[i];
                            token = ")";
                            valor = 5;
                            estado = -1;
                        }
                        else if (cadena[i] == '{') //Solo es un caracter por lo que no necesita estado propio
                        {
                            lexema += cadena[i];
                            token = "{";
                            valor = 6;
                            estado = -1;
                        }
                        else if (cadena[i] == '}') //Solo es un caracter por lo que no necesita estado propio
                        {
                            lexema += cadena[i];
                            token = "}";
                            valor = 7;
                            estado = -1;
                        }
                        else if (cadena[i] == '=') //Puede ser relacional o solo =
                        {
                            estado = 5;
                            lexema += cadena[i];
                            token = "=";
                            valor = 8;
                        }
                        else if (cadena[i] == '<' || cadena[i] == '>') //Relacional
                        {
                            estado = 5;
                            lexema += cadena[i];
                            token = "opRelacional";
                            valor = 17;
                        }
                        else if (cadena[i] == '!') //Es error a menos que siga un '='
                        {
                            estado = 5;
                            lexema += cadena[i];
                            token = "error";
                            valor = -1;
                        }
                        else if (cadena[i] == '+' || cadena[i] == '-') //Solo un caracter no necesita estado
                        {
                            lexema += cadena[i];
                            token = "opSuma";
                            valor = 14;
                            estado = -1;
                        }
                        else if (cadena[i] == '*' || cadena[i] == '/') //No necesita estado
                        {
                            lexema += cadena[i];
                            token = "opMultiplicacion";
                            valor = 16;
                            estado = -1;
                        }
                        else if (cadena[i] == '|' || cadena[i] == '&') //Estado opLogico
                        {
                            lexema += cadena[i];
                            token = "error";
                            valor = -1;
                            estado = 6;
                        }
                        else if (cadena[i] == '$') //No necesita estado
                        {
                            lexema += cadena[i];
                            token = "$";
                            valor = 18;
                            estado = -1;
                        }
                        else
                        {
                            lexema += cadena[i];
                            token = "error";
                            valor = -1;
                            estado = -1;
                        }
                        i++;
                    }
                    else if (estado == 1)  //Estado del id
                    {
                        if (Char.IsLetter(cadena, i) || cadena[i] == '_' || Char.IsDigit(cadena, i))
                        {
                            estado = 1;
                            lexema += cadena[i];
                            i++;
                        }
                        else //se determina si es palabra reservada
                        {
                            estado = -1;
                            if (lexema == "int" || lexema == "float" || lexema == "char" || lexema == "void")
                            {
                                token = "tipoDeDato";
                                valor = 0;
                            }
                            else if (lexema == "if")
                            {
                                token = lexema;
                                valor = 9;
                            }
                            else if (lexema == "while")
                            {
                                token = lexema;
                                valor = 10;
                            }
                            else if (lexema == "return")
                            {
                                token = lexema;
                                valor = 11;
                            }
                            else if (lexema == "else")
                            {
                                token = lexema;
                                valor = 12;
                            }
                            else
                            {
                                token = "id";
                                valor = 1;
                            }
                        }
                    }
                    else if (estado == 2) //estado de entero (constante)
                    {
                        if (Char.IsDigit(cadena, i))
                        {
                            estado = 2;
                            lexema += cadena[i];
                            i++;
                        }
                        else if (cadena[i] == '.') // puede ser real (constante)
                        {
                            estado = 3;
                            lexema += cadena[i];
                            i++;
                            token = "error";
                            valor = -1;
                        }
                        else
                            estado = -1;
                    }
                    else if (estado == 3) // Estado de transicion entero a real
                    {
                        if (Char.IsDigit(cadena, i))
                        {
                            estado = 4;
                            lexema += cadena[i];
                            token = "constante";
                            valor = 13;
                            i++;
                        }
                        else
                            estado = -1;

                    }
                    else if (estado == 4) // Estado de real (constante)
                    {
                        if (Char.IsDigit(cadena, i))
                        {
                            estado = 4;
                            lexema += cadena[i];
                            i++;
                        }
                        else
                            estado = -1;
                    }
                    else if (estado == 5) //Estado relacional
                    {
                        if (cadena[i] == '=') //Si llegan a este estado (=,<,>,!) pueden recibir un '=' mas
                        {
                            lexema += cadena[i];
                            token = "opRelacional"; // '=' se vuelve opRelacional
                            valor = 17;
                            i++;
                        }
                        estado = -1;    //Si no es un '=' se mantienen igual y sale
                    }
                    else if (estado == 6) //Estado opLogico
                    {
                        if (lexema[0] == cadena[i])
                        {
                            lexema += cadena[i];
                            token = "opLogico";
                            valor = 15;
                            i++;
                        }
                        estado = -1;
                    }
                    else //NO DEBERIA DE ENTRAR NUNCA
                        estado = -1;
                } // fin while por lexema
                estado = 0;
                tokens.Add(new Token() { tipo = token, identificador = valor, lexema = lexema });
            } //fin while que recorre la cadena
            dataGridViewLexico.DataSource = tokens;
        }
    }
}
