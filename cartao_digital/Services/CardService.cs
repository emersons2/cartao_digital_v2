// public class CardService
// {
//     public List<Card> GetCustomerCards(string documentNumber)
//     {
//         var customer = CustomerRepository.GetCustomers()
//             .FirstOrDefault(customer => customer.DocumentNumber == documentNumber);

//         if (customer == null)
//         {
//             return [];
//         }

//         var cards = CardRepository.GetCards().Where(x => x.CustomerId == customer.CustomerId);

//         return cards.ToList();
//     }
// }