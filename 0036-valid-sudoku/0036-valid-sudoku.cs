public class Solution {
    public bool IsValidSudoku(char[][] board) {
                    

        return CheckDuplicate(board);
    }
    public bool CheckDuplicate(char[][] board)
    {

        HashSet<string> seen = new HashSet<string>();

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                char current = board[i][j];

                if (current != '.') {
                    string rowCheck = $"row {i} contains {current}";
                    string colCheck = $"col {j} contains {current}";
                    string gridCheck = $"grid {i / 3}-{j / 3} contains {current}";

                    // Check if any condition is violated
                    if (!seen.Add(rowCheck) || !seen.Add(colCheck) || !seen.Add(gridCheck)) {
                        return false;
                    }
                }
            }
        }

        return true;
    }
    
    
  
}