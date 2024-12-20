public class Solution {
    public bool IsValid(string s) {
        // Dấu ngoặc mở và đóng
        char[] openBracket = { '(', '{', '[' };
        char[] closeBracket = { ')', '}', ']' };

        // Dấu ngoặc mở và đóng tương ứng
        Dictionary<char, char> bracketMap = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        // Kiểm tra độ dài chuỗi
        int numsTextInput = s?.Length ?? 0;

        
        if (numsTextInput == 0) return false;
        if (numsTextInput % 2 != 0) return false;
        if (closeBracket.Contains(s[0])) return false;

        Stack<char> stack = new Stack<char>();

        
        for (int i = 0; i < numsTextInput; i++)
        {
            char currentChar = s[i];

            // Nếu là dấu ngoặc mở, đẩy vào stack
            if (openBracket.Contains(currentChar))
            {
                stack.Push(currentChar);
            }
            // Nếu là dấu ngoặc đóng
            else if (closeBracket.Contains(currentChar))
            {
                if (stack.Count == 0) return false;  // Không có ngoặc mở tương ứng
                char top = stack.Pop();  // Lấy ngoặc mở ở đỉnh stack
                if (bracketMap[top] != currentChar) return false;
            }
        }
        return stack.Count == 0;
        
    }
}