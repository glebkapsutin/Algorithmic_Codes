using System.Linq;

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int a1 = m - 1;

        int a2 = n - 1;

        int a = m + n - 1;

        while (nums1[a1] > 0 && nums2[a2] > 0)
        {
            if (nums1[a1] > nums2[a2])
            {
                nums1[a] = nums1[a1];
                a1 -= 1;
            }
            else
            {
                nums1[a] = nums2[a2];
                a2 -= 1;
            }
            a -= 1;


        }
        while (a2 >= 0)
        {
            nums1[a] = nums2[a2];
            a2--;
            a--;
        }




    }
    public int RemoveElement(int[] nums, int val)
    {

        int k = 0;

        for (int i = 0; i < nums.Length; i++)
        {

            if (nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }


        }

        return k;

    }
    public int MajorityElement(int[] nums)
    {
        int n = nums.Length;
        int k = 1;
        int candidate = nums[0];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == candidate)
            {
                k++;
            }
            if (nums[i] != candidate)
            {
                k--;
            }
            if (k == 0)
            {
                candidate = nums[i];
                k = 1;
            }
        }
        return candidate;
    }
    public bool IsPalindrome(string s)
    {

        int left = 0;
        int right = s.Length - 1;


        if (string.IsNullOrEmpty(s))
        {
            return true;
        }
        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }
            left++;
            right--;
        }
        return true;



    }
    public bool IsSubsequence(string s, string t)
    {

        if (s.Length > t.Length) return false;
        if (s.Length == 0) return true;
        int indexS = 0;
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == s[indexS])
            {
                indexS++;

            }
            if (indexS == s.Length)
            {
                return true;
            }


        }
        return false;
    }
    public int MinSubArrayLen(int target, int[] nums)
    {
        // Проверка краевых случаев
        if (nums.Length == 0 || nums.Sum() < target)
        {
            return 0;
        }

        int start = 0;
        int end = 0;
        int currentSum = 0;
        int minLength = int.MaxValue;

        // Пока end не достиг конца массива
        while (end < nums.Length)
        {
            // Добавляем элемент в сумму
            currentSum += nums[end];

            // Если сумма >= target, пытаемся уменьшить окно
            while (currentSum >= target)
            {
                // Обновляем минимальную длину
                minLength = Math.Min(minLength, end - start + 1);
                // Уменьшаем окно, убирая элемент с начала
                currentSum -= nums[start];
                start++;
            }

            // Расширяем окно
            end++;
        }

        // Если minLength не изменился, возвращаем 0
        return minLength == int.MaxValue ? 0 : minLength;
    }
    public void Rotate(int[] nums, int k)
    {
        if (nums.Length <= 1)
        { return; }
        if (k > nums.Length)
        {
            k %= nums.Length;
        }
        if (k == 0)
        {
            return;
        }
        int left = 0;
        int right = nums.Length - 1;
        // Шаг 1: Реверс всего массива
        Reverse(nums, 0, nums.Length - 1);

        // Шаг 2: Реверс первых k элементов
        Reverse(nums, 0, k - 1);

        // Шаг 3: Реверс оставшихся элементов
        Reverse(nums, k, nums.Length - 1);

    }
    private void Reverse(int[] nums, int left, int right)
    {

        while (left < right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }

}