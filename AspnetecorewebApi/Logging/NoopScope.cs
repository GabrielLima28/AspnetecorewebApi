namespace AspnetecorewebApi.Logging
{
    public  class NoopScope : IDisposable
    {
        public static NoopScope Instance { get; } = new NoopScope();
        private NoopScope() { }
        public void Dispose() { }
    }
}
