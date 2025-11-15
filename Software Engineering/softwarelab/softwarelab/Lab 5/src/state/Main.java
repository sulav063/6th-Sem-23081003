package state;

interface State {
    void handle();
}

class StartState implements State {
    public void handle() { System.out.println("Player is in Start State"); }
}

class StopState implements State {
    public void handle() { System.out.println("Player is in Stop State"); }
}

class Player {
    private State state;
    public void setState(State state) { this.state = state; }
    public void pressButton() { state.handle(); }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Compiled classes location:");
        System.out.println(System.getProperty("user.dir") + "\\out\\production\\Lab 5\n");

        Player player = new Player();
        State start = new StartState();
        State stop = new StopState();

        player.setState(start);
        player.pressButton();

        player.setState(stop);
        player.pressButton();
    }
}
