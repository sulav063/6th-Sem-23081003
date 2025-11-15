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
//momento pattern:
//Saves an object's state (like a snapshot)
//Restores it later without breaking encapsulation
//Think of it like "Undo" in a text editor.

public class Main {
    public static void main(String[] args) {

        Editor editor = new Editor();
        History history = new History();

        editor.type("Hello ");
        history.push(editor.save());

        editor.type("World ");
        history.push(editor.save());

        editor.type("!!!");
        System.out.println("Current: " + editor.getContent());
        // Output: Hello World !!!

        // UNDO last change
        EditorMemento m = history.pop();
        if (m != null) editor.restore(m);
        System.out.println("After undo: " + editor.getContent());
        // Output: Hello World

        // UNDO again
        m = history.pop();
        if (m != null) editor.restore(m);
        System.out.println("After second undo: " + editor.getContent());
        // Output: Hello
    }

}