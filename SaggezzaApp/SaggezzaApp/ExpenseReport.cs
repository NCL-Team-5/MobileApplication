using System;
using Plugin.CloudFirestore.Attributes;

namespace SaggezzaApp {
/*
    Description: This page holds the C# code for backend processing of the expecnse report.
    Authors:Cameron Chrisholm
    Release Date: 03/03/2020
    Last editied: 10/04/2020
*/
    public class ExpenseReport
    {
        // Time + date submitted
        [ServerTimestamp]
        public DateTime SubmittedAt { get; set; }

        // Date person is claiming for
        public DateTime ClaimDate { get; set; }

        // Link to pictures of receipt uploaded, Document Reference
        [MapTo("ReceiptPhoto")]
        public string ReceiptPic { get; set; }

        // Extra text included by user
        public string Description { get; set; }

        // Client Name/Saggezza
        public string ClientName { get; set; }

        // Category of expense report
        public string Category { get; set; }

        // Payment method used
        public string PaymentMethod { get; set; }

        // Billable to client (True/False)
        public bool BillableToClient { get; set; }

        // ID of user
        public string UserID { get; set; }

        // Amount claimed as decimal
        public decimal Amount { get; set; }

        // Currency used
        public string Currency { get; set; }

        // Status of submission
        public string Status { get; set; }

    }
}
