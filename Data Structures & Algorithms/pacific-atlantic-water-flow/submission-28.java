class Solution {
int[][] dir = {{0,1},{1,0},{0,-1},{-1,0}};
public List<List<Integer>> pacificAtlantic(int[][] heights) {
List<List<Integer>> res = new ArrayList<>();
boolean[][] pacific = new boolean[heights.length][heights[0].length];
boolean[][] atlantic = new boolean[heights.length][heights[0].length];
int row = heights.length, col = heights[0].length;
for(int i=0;i<col;i++){
dfs(0,i, Integer.MIN_VALUE , pacific, heights);
dfs(row-1,i, Integer.MIN_VALUE , atlantic, heights);
}

    for(int i=0;i<row;i++){
        dfs(i,0, Integer.MIN_VALUE , pacific, heights);
        dfs(i, col-1 , Integer.MIN_VALUE , atlantic, heights);
    }

  for(int i=0;i<heights.length;i++){
      for(int j=0;j<heights[0].length;j++){
          if(pacific[i][j] && atlantic[i][j]){
              res.add(Arrays.asList(i,j));
          }
      }
  }
  return res;

}

public void dfs(int i, int j, int prev, boolean[][] ocean, int[][] heights){
    if(i<0 || i>=ocean.length || j<0 || j>=ocean[0].length){
        return;
    }
    if(!ocean[i][j] && heights[i][j]>=prev){
        ocean[i][j]=true;
        for(int row=0;row<4;row++){
            dfs(i+dir[row][0], j+dir[row][1],  heights[i][j], ocean, heights);
        }
    }


}
}