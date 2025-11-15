package observer;

import java.util.ArrayList;
import java.util.List;

interface Observer {
    void update(String news);
}

class MobileApp implements Observer {
    private final String name;
    public MobileApp(String name) { this.name = name; }
    public void update(String news) {
        System.out.println(name + " received news: " + news);
    }
}

class TVChannel implements Observer {
    public void update(String news) {
        System.out.println("TV Channel broadcasting: " + news);
    }
}

class NewsAgency {
    private final List<Observer> observers = new ArrayList<>();
    public void addObserver(Observer o) { observers.add(o); }
    public void removeObserver(Observer o) { observers.remove(o); }
    public void notifyObservers(String news) {
        for (Observer o : observers) o.update(news);
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Compiled classes location:");
        System.out.println(System.getProperty("user.dir") + "\\out\\production\\Lab 5\n");

        NewsAgency agency = new NewsAgency();
        MobileApp app1 = new MobileApp("AppOne");
        MobileApp app2 = new MobileApp("AppTwo");
        TVChannel channel = new TVChannel();

        agency.addObserver(app1);
        agency.addObserver(app2);
        agency.addObserver(channel);

        agency.notifyObservers("Breaking News: Observer Pattern Implemented!");
    }
}
