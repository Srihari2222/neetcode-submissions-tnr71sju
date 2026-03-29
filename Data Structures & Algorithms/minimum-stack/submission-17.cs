public class MinStack {
    private long min;
    private Stack<Long> stack;

    public MinStack() {
        stack = new Stack<>();
    }

    public void Push(int val) {
        if (stack.isEmpty()) {
            stack.push(0L);
            min = val;
        } else {
            stack.push(val - min);
            if (val < min) min = val;
        }
    }

    public void Pop() {
        if (stack.isEmpty()) return;

        long pop = stack.pop();

        if (pop < 0) min -= pop;
    }

    public int Top() {
        long top = stack.peek();
        return top > 0 ? (int)(top + min) : (int)(min);
    }

    public int GetMin() {
        return (int)min;
    }
}