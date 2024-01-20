using HorseMoney.Domain.Common;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Domain.Interfaces.WalletInterfaces;
using HorseMoney.Domain.Dto;
using HorseMoney.Domain.Messages;

namespace HorseMoney.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    public class WalletController : BaseController
    {
        private readonly ICreateWalletUseCase _createWallet;
        private readonly IDeleteWalletUseCase _deleteWallet;
        private readonly IGetAllAsyncWalletUseCase _getAll;
        private readonly IGetByIdWalletUseCase _getById;
        private readonly IUpdateWalletUseCase _updateWallet;

        public WalletController(
            ICreateWalletUseCase createWallet, 
            IDeleteWalletUseCase deleteWallet, 
            IGetAllAsyncWalletUseCase getAll, 
            IGetByIdWalletUseCase getById, 
            IUpdateWalletUseCase updateWallet)
        {
            _createWallet = createWallet;
            _deleteWallet = deleteWallet;
            _getAll = getAll;
            _getById = getById;
            _updateWallet = updateWallet;
        }


        [HttpPost]
        public async Task<ActionResult<BasicResult>> Create([FromBody] WalletDto walletCreateDto)
        {
            var result = await _createWallet.Execute(walletCreateDto);
            return ResponseBase(HttpStatusCode.Created, result, CommonMessage.OperationSucess);
        }

        [HttpPut]
        public async Task<ActionResult<BasicResult>> Update([FromBody] WalletUpdateDto walletUpdateDto)
        {
            var result = await _updateWallet.Execute(walletUpdateDto);
            return ResponseBase(HttpStatusCode.Accepted, result);
        }

        [HttpDelete]
        public async Task<ActionResult<BasicResult>> Delete([FromRoute] Guid id)
        {
            var result = await _deleteWallet.Execute(id);
            return ResponseBase(HttpStatusCode.Accepted, result, CommonMessage.OperationSucess);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BasicResult>> GetById([FromRoute] Guid id)
        {
            var result = await _getById.Execute(id);
            return ResponseBase(HttpStatusCode.Accepted, result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BasicResult>> GetAll([FromQuery] int skip, [FromQuery] int take)
        {       
            var result = await _getAll.Execute(new(skip, take));
            return ResponseBase(HttpStatusCode.Accepted, result);
        }
    }
}
