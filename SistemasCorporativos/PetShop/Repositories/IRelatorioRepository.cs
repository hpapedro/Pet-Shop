using System;
using PetShop.Models;

namespace PetShop.Repositories;
public interface IRelatorioRepository
{
    RelatorioGeral ObterTotalEntradas();
    RelatorioGeral ObterTotalSaidas();
}

