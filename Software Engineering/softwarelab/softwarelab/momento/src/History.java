/**
 *
 * ███████╗ █████╗ ███╗   ██╗██████╗ ██╗██████╗
 * ██╔════╝██╔══██╗████╗  ██║██╔══██╗██║██╔══██╗
 * ███████╗███████║██╔██╗ ██║██║  ██║██║██████╔╝
 * ╚════██║██╔══██║██║╚██╗██║██║  ██║██║██╔═══╝
 * ███████║██║  ██║██║ ╚████║██████╔╝██║██║
 * ╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝╚═╝
 *
 * @author HP VICTUS on 11/15/2025
 */
import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

// Keeps track of all saved states (like an undo stack)
public class History {
    private final Stack<EditorMemento> undoStack = new Stack<>();

    // Save state (push to top)
    public void push(EditorMemento memento) {
        undoStack.push(memento);
        System.out.println("Saved state: " + memento.getSavedContent());
    }

    // Undo: remove and return last saved state
    public EditorMemento pop() {
        if (undoStack.isEmpty()) {
            System.out.println("Nothing to undo!");
            return null;
        }
        EditorMemento last = undoStack.pop();
        System.out.println("Undo: Restored '" + last.getSavedContent() + "'");
        return last;
    }
}