using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPFCNPJ
{
    public class CPFCNPJ
    {

        
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static string tpPessoa(string docto)
        {
            if (IsCnpj(docto) == true)
                return "Juridica";
            else if (IsCpf(docto) == true)
                return "Fisica";
            else
                return "";
        }

        public static string formataDoc(string docto)
        {
            string cpfcnpj = docto.Replace(" ", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "");
            string antcpf = docto;
            if (cpfcnpj.Length < 11)
                cpfcnpj = cpfcnpj.PadLeft(11, '0');
            try
            {
                cpfcnpj = Convert.ToUInt64(cpfcnpj).ToString(@"000\.000\.000\-00");
                if (IsCpf(cpfcnpj) == false)
                {
                    cpfcnpj = docto.Replace(" ", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "");
                    if (cpfcnpj.Length < 14)
                        cpfcnpj = cpfcnpj.PadLeft(14, '0');
                    cpfcnpj = Convert.ToUInt64(cpfcnpj).ToString(@"00\.000\.000\/0000\-00");
                    if (IsCnpj(cpfcnpj) == false)
                        cpfcnpj = "";
                }
            }
            catch
            {
                try
                {
                    cpfcnpj = docto.Replace(" ", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "");
                    if (cpfcnpj.Length < 14)
                        cpfcnpj = cpfcnpj.PadLeft(14, '0');
                    cpfcnpj = Convert.ToUInt64(cpfcnpj).ToString(@"00\.000\.000\/0000\-00");
                    if (IsCnpj(cpfcnpj) == false)
                        cpfcnpj = "";
                }
                catch (Exception ex)
                {
                    cpfcnpj = "";
                    Console.WriteLine("Erro ao converter docto:" + antcpf + "\r\n" + ex.Message);
                }



            }
            if (cpfcnpj == "")
                Console.WriteLine("Docto Não é um CNPJ ou CPF Valido");
            return cpfcnpj;
        }

    }
}
