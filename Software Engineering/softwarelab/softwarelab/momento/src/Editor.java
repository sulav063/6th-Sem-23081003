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
// The class whose state we want to save/restore
public class Editor {
    private String content;

    public Editor() {
        this.content = "";
    }

    // Change content
    public void type(String words) {
        this.content += words;
    }

    // Get current content
    public String getContent() {
        return content;
    }

    // Save current state into a Memento
    public EditorMemento save() {
        return new EditorMemento(this.content);
    }

    // Restore state from a Memento
    public void restore(EditorMemento memento) {
        this.content = memento.getSavedContent();
    }
}