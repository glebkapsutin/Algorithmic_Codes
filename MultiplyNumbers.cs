using System.Text;

namespace First_cods_in_university.Multi
{
    public class MultiplyNumbers
    {
        public static string MultiplyLargeNumbers(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;
            int[] result = new int[len1 + len2];

            for (int i = len1 - 1; i >= 0; i--)
            {
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int pos1 = i + j;
                    int pos2 = i + j + 1;

                    int sum = mul + result[pos2];
                    result[pos2] = sum % 10;
                    result[pos1] += sum / 10;
                }
            }

            string resultStr = string.Join("", result).TrimStart('0');
            return resultStr.Length == 0 ? "0" : resultStr;
        }
        public static string KaratsubaMultiply(string num1,string num2)
        {
            if (num1.Length == 1 && num2.Length == 1)
            {
                return (int.Parse(num1) * int.Parse(num2)).ToString();
            }

            int len1 = num1.Length;
            int len2 = num2.Length;

            int maxLen = Math.Max(len1, len2);

            if(maxLen %2!= 0)
            {
                maxLen++;
            }
            num1 = num1.PadLeft(maxLen, '0');
            num2 = num2.PadLeft(maxLen, '0');

            int halfLen = maxLen / 2;
            string high1 = num1.Substring(0, halfLen); // Старшая половина
            string low1 = num1.Substring(halfLen);     // Младшая половина

            // Разделяем второе число на старшую и младшую части
            string high2 = num2.Substring(0, halfLen); // Старшая половина
            string low2 = num2.Substring(halfLen);     // Младшая половина

            // Рекурсивно умножаем младшие части чисел: z0 = low1 * low2
            string z0 = KaratsubaMultiply(low1, low2);

            // Рекурсивно умножаем суммы старших и младших частей: z1 = (low1 + high1) * (low2 + high2)
            string z1 = KaratsubaMultiply(AddStrings(low1, high1), AddStrings(low2, high2));

            // Рекурсивно умножаем старшие части чисел: z2 = high1 * high2
            string z2 = KaratsubaMultiply(high1, high2);

            
            // 1. Добавляем z2, сдвинутый на два раза по halfLen влево (то есть умноженный на 10^2*halfLen)
            // 2. Вычитаем (z1 - z2 - z0) и сдвигаем результат на один раз по halfLen влево
            // 3. Добавляем z0
            string result = AddStrings(
                AddStrings(ShiftLeft(z2, 2 * halfLen), 
                        ShiftLeft(SubtractStrings(z1, AddStrings(z2, z0)), halfLen)), 
                z0);

            // Убираем ведущие нули из результата и возвращаем его
            return result.TrimStart('0');
        }
        static string ShiftLeft(string num, int positions)
        {
            return num + new string('0', positions); // Добавляем указанное количество нулей в конец числа
        }
        static string AddStrings(string num1, string num2)
    {
        StringBuilder result = new StringBuilder();
        int carry = 0;  // Перенос
        int maxLength = Math.Max(num1.Length, num2.Length);

        // Выровняем длины чисел, добавив нули слева
        num1 = num1.PadLeft(maxLength, '0');
        num2 = num2.PadLeft(maxLength, '0');

        // Складываем числа с конца
        for (int i = maxLength - 1; i >= 0; i--)
        {
            int digit1 = num1[i] - '0'; // Преобразуем символ в число
            int digit2 = num2[i] - '0';
            int sum = digit1 + digit2 + carry;
            carry = sum / 10;           // Если сумма больше 9, запоминаем перенос
            result.Insert(0, (sum % 10).ToString()); // Добавляем младшую цифру суммы в начало
        }

        // Если остался перенос
        if (carry > 0)
        {
            result.Insert(0, carry.ToString());
        }

        return result.ToString();
    }
    static string SubtractStrings(string num1, string num2)
    {
        StringBuilder result = new StringBuilder();
        int borrow = 0;  // Заем
        int maxLength = Math.Max(num1.Length, num2.Length);

        // Выровняем длины чисел, добавив нули слева
        num1 = num1.PadLeft(maxLength, '0');
        num2 = num2.PadLeft(maxLength, '0');

        // Вычитаем числа с конца
        for (int i = maxLength - 1; i >= 0; i--)
        {
            int digit1 = num1[i] - '0';
            int digit2 = num2[i] - '0' + borrow; // заем
            if (digit1 < digit2)
            {
                digit1 += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            result.Insert(0, (digit1 - digit2).ToString());
        }

        // Удалим ведущие нули
        return result.ToString().TrimStart('0');
    }



    }
}