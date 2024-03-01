namespace Test.Setup;

using static DatabaseContextFactory;

public class QueryTestBase : IDisposable
{
	protected static DatabaseContext Context => Create();

	public void Dispose() => Destroy(Context);
}

