namespace BehsamFramework.Entity
{
	public class IEntity:object
	{

        [Dapper.Contrib.Extensions.Key]
        public System.Guid Id { get; set; }

        public IEntity():base()
        {
            
        }
	}

    public class IEntity<T> :object
    {
        
        //public T Id { get; set; }

        public IEntity():base()
        {
                
        }
    }

}
