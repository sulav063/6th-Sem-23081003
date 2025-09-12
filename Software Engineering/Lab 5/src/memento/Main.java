package memento;

import java.util.Stack;

// Memento
class TextMemento {
    private final String state;
    public TextMemento(String state) { this.state = state; }
    public String getState() { return state; }
}

// Originator
class TextEditor {
    private String text = "";
    public void type(String newText) { text += newText; }
    public String getText() { return text; }
    public TextMemento save() { return new TextMemento(text); }
    public void restore(TextMemento m) { text = m.getState(); }
}

// Caretaker
class History {
    private final Stack<TextMemento> undoStack = new Stack<>();
    private final Stack<TextMemento> redoStack = new Stack<>();

    public void save(TextMemento m) { undoStack.push(m); redoStack.clear(); }
    public TextMemento undo(TextEditor editor) {
        if (!undoStack.isEmpty()) {
            TextMemento m = undoStack.pop();
            redoStack.push(editor.save());
            return m;
        }
        return null;
    }
    public TextMemento redo(TextEditor editor) {
        if (!redoStack.isEmpty()) {
            TextMemento m = redoStack.pop();
            undoStack.push(editor.save());
            return m;
        }
        return null;
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println(System.getProperty("user.dir") + "\\out\\production\\Lab 5\n");

        // Memento code
        TextEditor editor = new TextEditor();
        History history = new History();

        editor.type("Hello ");
        history.save(editor.save());

        editor.type("World!");
        history.save(editor.save());

        System.out.println("Current: " + editor.getText());

        editor.restore(history.undo(editor));
        System.out.println("After Undo: " + editor.getText());

        editor.restore(history.redo(editor));
        System.out.println("After Redo: " + editor.getText());
    }
}
