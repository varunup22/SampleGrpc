using Grpc.Core;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SamplePaymentService.Services
{
    public class PaymentService : PaymentServicce.PaymentServicceBase
    {
        private readonly ILogger<PaymentService> _logger;       
        public PaymentService(ILogger<PaymentService> logger)
        {
            _logger = logger;           
        }

        public override Task<MakePaymentReply> MakePayment(MakePaymentRequest request, ServerCallContext context)
        {
            var transactionId = Guid.NewGuid().ToString();
            _logger.LogInformation($"Make payment {transactionId}");
          

            return Task.FromResult (new MakePaymentReply
            {
                TransactionId = transactionId + "For" + request.ProductId
            });
        }
    }
}
