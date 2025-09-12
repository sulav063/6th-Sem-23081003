package iterator;

import java.util.Iterator;
import java.util.List;
import java.util.ArrayList;

class NameCollection implements Iterable<String> {
    private final List<String> names = new ArrayList<>();
    public void addName(String name) { names.add(name); }
    public Iterator<String> iterator() { return names.iterator(); }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Compiled classes location:");
        System.out.println(System.getProperty("user.dir") + "\\out\\production\\Lab 5\n");

        NameCollection collection = new NameCollection();
        collection.addName("Sulav");
        collection.addName("Subina");
        collection.addName("Pragesh");

        for (String name : collection) {
            System.out.println("Name: " + name);
        }
    }
}
