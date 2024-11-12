using FluentValidation;
using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity
    {
        public DrugStore(string drugNetwork, int number, Address address, DrugNetwork network)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;
            Network = network;
            
            Validate();
            
            network.DrugStores.Add(this);
        }

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }

        // Навигационное свойство для связи с DrugNetwork
        public DrugNetwork Network { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        
        private void Validate()
        {
            var validator = new DrugStoreValidator();
            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
                
                throw new ValidationException(errors);
            }
        }
    }
}