// SPDX-FileCopyrightText: 2026 Tayra Sakurai
// 
// SPDX-License-Identifier: AGPL-3.0-or-later

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyBalanceSheet.Models
{
    public class Item : IComparable<Item>
    {
        public int Id { get; set; }

        [Display(Name = "日時")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "この項目は必須です．")]
        public DateTime DateAndTime { get; set; } = DateTime.Now;

        [Column(TypeName = "ntext")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "項目名")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "この項目は必須です．")]
        public string ItemName { get; set; } = string.Empty;

        [Display(Name = "支出")]
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "この項目は必須です．")]
        public decimal Expense { get; set; } = decimal.Zero;

        [Display(Name = "収入")]
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "この項目は必須です．")]
        public decimal Income { get; set; } = decimal.Zero;

        public int CompareTo(Item? other)
        {
            if (other is null)
                return 1;
            int dateAndTimeComp = DateAndTime.CompareTo(other.DateAndTime);
            if (dateAndTimeComp != 0)
                return dateAndTimeComp;
            return Id.CompareTo(other.Id);
        }
    }
}
