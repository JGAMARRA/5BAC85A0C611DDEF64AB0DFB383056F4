using SistemaPlanificacionOT.Domain.Models.Common;
using System;
using System.Collections.Generic;

namespace SistemaPlanificacionOT.Infraestructure.Helpers
{
    public class DataValidation
    {
        //antes
        //public static bool OnlyLetters1(string cadena)
        //{
        //    bool ok = false;
        //    if (string.IsNullOrWhiteSpace(cadena) == false)
        //    {
        //        for (int i = 0; i <= cadena.Length - 1; i++)
        //        {
        //            if (char.IsDigit(cadena[i]))
        //            {
        //                break;
        //            }
        //        }
        //        ok = true;
        //    }
        //    return ok;
        //}
        public static bool OnlyLetters1(string cadena)
        {
            bool ok = true;
            if (string.IsNullOrWhiteSpace(cadena) == false)
            {
                for (int i = 0; i <= cadena.Length - 1; i++)
                {
                    if (char.IsDigit(cadena[i]))
                    {
                        ok = false;
                        break;
                    }
                }
               
            }
            return ok;
        }
        public static bool OnlyNumbers1(string cadena)
        {
            bool ok = true;
            if (string.IsNullOrWhiteSpace(cadena) == false)
            {
                for (int i = 0; i <= cadena.Length - 1; i++)
                {
                    if (!char.IsDigit(cadena[i]))
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }
        public static bool ValidateLength1(string cadena, int MaxLength, int MinLength = 0)
        {
            bool ok = false;
            if (MinLength == 0)
            { ok = cadena.Length == MaxLength ? true : false; }
            else
            { ok = cadena.Length >= MinLength && cadena.Length <= MaxLength ? true : false; }

            return ok;
        }

        public static bool solo1Blanco(string cadena)
        {
            if (cadena.ToString().TrimEnd().Contains("  "))
            {
                return false;
            }
            return true;
        }
        public static string ConvertirEntero(int iVal, bool esColumna = true)
        {
            int iAlpha, iRemainder;
            iVal = iVal + 1;
            if (esColumna)
            {
                iAlpha = (iVal / 27);
                iRemainder = iVal - (iAlpha * 26);
                if (iAlpha > 0)
                {
                    return Convert.ToChar(iAlpha + 64).ToString();
                }
                if (iRemainder > 0)
                {
                    return Convert.ToChar(iRemainder + 64).ToString();
                }
            }
            return iVal.ToString();
        }

        public static List<ExcelErrors> Valida(Range oErr1, string claves)
        {
            List<ExcelErrors> ListErr = new List<ExcelErrors>();
            string[] lclaves = claves.Split('|');
            //Valida campo obligatorio
            if ((lclaves[0].ToString() == "S") && (string.IsNullOrWhiteSpace(oErr1.value.ToString())))
            {
                //oErr1.value.ToString()
                ListErr.Add(new ExcelErrors("NO REGISTRADO", "Celda debe ingresarse", ConvertirEntero(oErr1.row, false), ConvertirEntero(oErr1.column)));
                return ListErr;
            }
            //Valida solo numeros
            if ((lclaves[1].ToString() == "S") && (OnlyNumbers1(oErr1.value.ToString()) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false))
            {
                ListErr.Add(new ExcelErrors(oErr1.value.ToString(), "Celda debe contener solo números", ConvertirEntero(oErr1.row, false), ConvertirEntero(oErr1.column)));
                return ListErr;
            }
            //Valida solo letras
            if ((lclaves[2].ToString() == "S") && (OnlyLetters1(oErr1.value.ToString()) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false))
            {
                ListErr.Add(new ExcelErrors(oErr1.value.ToString(), "Celda debe contener solo letras", ConvertirEntero(oErr1.row, false), ConvertirEntero(oErr1.column)));
                return ListErr;
            }
            //Valida solo tipo documento
            if ((lclaves[3].ToString() == "S") && (OnlyDoc(oErr1.value.ToString()) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false))
            {
                ListErr.Add(new ExcelErrors(oErr1.value.ToString(), "Celda invalida, debe ser DNI o RUC", ConvertirEntero(oErr1.row, false), ConvertirEntero(oErr1.column)));
                return ListErr;
            }

            if ((lclaves[4].ToString() == "S") && (solo1Blanco(oErr1.value.ToString()) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false))
            {
                ListErr.Add(new ExcelErrors(oErr1.value.ToString(), "Celda debe contener solo un espacio en blanco entre palabras", oErr1.row.ToString(), ConvertirEntero(oErr1.column)));
                return ListErr;
            }
            //Valida longitud
            if ((lclaves[5].ToString() == "S") && (ValidateLength1(oErr1.value.ToString(), Int32.Parse(lclaves[6].ToString()), Int32.Parse(lclaves[7].ToString())) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false))
            {
                if (lclaves[7].ToString() == "0")
                {
                    ListErr.Add(new ExcelErrors(oErr1.value.ToString(), "Celda debe tener " + lclaves[6].ToString() + " caracteres de longitud", ConvertirEntero(oErr1.row, false), ConvertirEntero(oErr1.column)));
                }
                else
                {
                    ListErr.Add(new ExcelErrors(oErr1.value.ToString(), "Celda debe tener entre " + lclaves[7].ToString() + " y " + lclaves[6].ToString() + " caracteres de longitud", ConvertirEntero(oErr1.row, false), ConvertirEntero(oErr1.column)));
                }
                return ListErr;
            }

            return ListErr;
        }
        public static List<ExcelErrors> Valida2(Range oErr1, string claves, Range oErr2)
        {
            List<ExcelErrors> ListErr = new List<ExcelErrors>();
            string[] lclaves = claves.Split('|');
            //indica que no es obligatorio que los dos esten completos
            if (((lclaves[0].ToString() == "N") && (oErr1.value.ToString() == "") && (oErr2.value.ToString().TrimEnd() == "")) == false)
            {
                //sin embargo debe soportar que los dos esten
                if ((lclaves[0].ToString() == "N") && ((oErr1.value.ToString() == "") || (oErr2.value.ToString().TrimEnd() == "")))
                {
                    ListErr.Add(new ExcelErrors("NO REGISTRADO", "Debe registrarse tanto el Tipo como el Numero del documento", ConvertirEntero(oErr2.row, false), ConvertirEntero(oErr2.column)));
                    return ListErr;
                }
            }


            //dni se escoge el parametro menor lclaves[6].ToString() 
            if ((lclaves[4].ToString() == "S") && (oErr1.value.ToString() == "DNI") && (ValidateLength1(oErr2.value.ToString(), Int32.Parse(lclaves[6].ToString()), 0) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false) && (string.IsNullOrWhiteSpace(oErr2.value.ToString()) == false))
            {

                ListErr.Add(new ExcelErrors(oErr2.value.ToString(), "Numero DNI debe tener 8 caracteres", ConvertirEntero(oErr2.row, false), ConvertirEntero(oErr2.column)));
                return ListErr;
            }
            if ((lclaves[4].ToString() == "S") && (oErr1.value.ToString() == "RUC") && (ValidateLength1(oErr2.value.ToString(), Int32.Parse(lclaves[5].ToString()), 0) == false) && (string.IsNullOrWhiteSpace(oErr1.value.ToString()) == false) && (string.IsNullOrWhiteSpace(oErr2.value.ToString()) == false))
            {
                //if ((oErr1.value.ToString() == "") || (oErr2.value.ToString().TrimEnd() == ""))
                //{
                //    ListErr.Add(new ExcelErrors(oErr2.value.ToString(), "Debe registrarse tanto el Tipo como el Numero del documento", ConvertirEntero(oErr2.row, false), ConvertirEntero(oErr2.column)));
                //    return ListErr;
                //}
                ListErr.Add(new ExcelErrors(oErr2.value.ToString(), "Numero RUC debe tener 11 caracteres", ConvertirEntero(oErr2.row, false), ConvertirEntero(oErr2.column)));
                return ListErr;
            }
            return ListErr;
        }


        public static bool OnlyDoc(string cadena)
        {
            bool ok = true;
            if ((cadena.ToUpper() == "DNI") || (cadena.ToUpper() == "RUC"))
            {
                ok = true;
            }
            else {
                ok = false;
            }
            return ok;
        }

        public static bool OnlyNumbers(string cadena)
        {
            bool ok = true;
            if (string.IsNullOrWhiteSpace(cadena))
            {
                ok = false;
            }
            else
            {
                for (int i = 0; i <= cadena.Length - 1; i++)
                {
                    if (!char.IsDigit(cadena[i]))
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }

        public static bool ValidateLength(string cadena, int MaxLength, bool EqualMax = false, int MinLength = 0)
        {
            bool ok = false;
            if (EqualMax)
            { ok = cadena.Length == MaxLength ? true : false; }
            else
            { ok = cadena.Length >= MinLength && cadena.Length <= MaxLength ? true : false; }

            return ok;
        }

        public static bool OnlyLetters(string cadena, bool empty = false)
        {
            bool ok = false;
            if (string.IsNullOrWhiteSpace(cadena))
            {
                ok = empty;
            }
            else
            {
                for (int i = 0; i <= cadena.Length - 1; i++)
                {
                    if (char.IsDigit(cadena[i]))
                    {
                        break;
                    }
                }
                ok = true;
            }
            return ok;
        }

        public static bool IsNumeric(string cadena, decimal MinValue = decimal.MinValue, decimal MaxValue = decimal.MaxValue, bool AllowZero = true)
        {
            bool isNumber;
            isNumber = Decimal.TryParse(Convert.ToString(cadena), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out decimal isItNumeric);

            if (isNumber)
                isNumber = (isItNumeric >= MinValue && isItNumeric <= MaxValue) ? true : false;

            if (isNumber)
                isNumber = isItNumeric == decimal.Zero ? AllowZero : true;

            return isNumber;
        }

        public static bool IsDate(string cadena)
        {
            bool ok;
            DateTime date;
            ok = DateTime.TryParse(Convert.ToString(cadena), out date);
            return ok;
        }
    }
}
