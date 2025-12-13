public abstract class ConsoleProgram {
    protected virtual Mode _startMode {get; set;}
    public ConsoleProgram(Mode StartMode){_startMode = StartMode;}
    public void Run() {_startMode.Run();}
}