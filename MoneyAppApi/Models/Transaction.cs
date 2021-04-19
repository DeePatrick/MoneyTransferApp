using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public enum TransactionType
    {
        [Display(Name = "Withdrawal / POS")]
        Withdraw = 1 ,

        [Display(Name = "Deposit / Transfer")]
        Save = 2,

        [Display(Name = "Pay a Bill")]
        PayBill = 3,

        [Display(Name = "Account Openning")]
        AccountOpenning = 4
    }

    public enum CardType
    {
        [Display(Name = "Verve")]
        Verve= 1,

        [Display(Name = "Master card")]
        Mastercard = 2,

        [Display(Name = "Visa card")]
        Visa = 3,

    }










    public class Transaction
    {
        [Required]
        public TransactionType TransactionType { get; set; }
        public int TransactionId { get; set; }
        public bool IsWithdrawal { get; set; }
        public string PayeeName { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        [MaxLength(10)]
        public string AccountNo { get; set; }
        public string Location { get; set; }

        [Required]
        public decimal BankCharge { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public string CardNo { get; set; }
        public CardType CardType { get; set; }

        public string CreateDate { get; set; }

        public string CreatedBy { get; set; }

    }
}


