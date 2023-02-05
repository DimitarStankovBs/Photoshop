namespace Photoshop.Data.Models.Abstraction
{
    using System;
    public class BaseModel
    {
        public Guid Id { get; set; }
        
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
        }
        
    }
}
