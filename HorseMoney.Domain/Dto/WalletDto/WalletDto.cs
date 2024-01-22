using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseMoney.Domain.Dto.WalletDto
{
    public record WalletDto(Guid Id, string Name, bool IsDeleted);
}
