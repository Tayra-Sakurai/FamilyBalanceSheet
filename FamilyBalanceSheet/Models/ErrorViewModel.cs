// SPDX-FileCopyrightText: 2026 Tayra Sakurai
// 
// SPDX-License-Identifier: AGPL-3.0-or-later

namespace FamilyBalanceSheet.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
