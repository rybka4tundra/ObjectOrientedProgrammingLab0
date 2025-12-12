public abstract class ConsoleProgram {
    protected abstract Mode _startMode {get; set;}
    public void Run() {
        _startMode.Run();
    }
}