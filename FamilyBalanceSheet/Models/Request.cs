// SPDX-FileCopyrightText: 2026 Tayra Sakurai
// 
// SPDX-License-Identifier: AGPL-3.0-or-later

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyBalanceSheet.Models
{
    public class Request : IComparable<Request>
    {
        [Display(Name = "ID")]
        public int? Id { get; set; }

        [Display(Name = "ユーザー名")]
        [Column(TypeName = "ntext")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "日時")]
        [Column(TypeName = "datetime")]
        public DateTime DateAndTime { get; set; } = DateTime.Now;

        [Display(Name = "残高")]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; } = decimal.Zero;

        [Display(Name = "承認状況")]
        [Column(TypeName = "binary(1)")]
        public bool IsAccepted { get; set; } = false;

        public int CompareTo(Request? other)
        {
            if (other == null) return 1;
            if (Id is not int id) return -1;
            if (other.Id is not int id2) return 1;

            int dComp = DateAndTime.CompareTo(other.DateAndTime);

            if (dComp != 0) return dComp;
            return id.CompareTo(id2);
        }
    }
}
