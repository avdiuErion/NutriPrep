using NutriPrep.DTOs;
using NutriPrep.Interfaces;
using NutriPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriPrep.Services
{
    public class MealsService : IMealsService
    {
        private readonly NutriPrepContext _context;
        private readonly IMealsRepository _mealsRepository;

        public object nrDarke { get; private set; }

        public MealsService(
            NutriPrepContext context,
            IMealsRepository mealsRepository
        )
        {
            _context = context;
            _mealsRepository = mealsRepository;
        }
        public async Task<List<List<Ushqimi>>> GetPlan(PayLoadDTO payload)
        {
            var rezultatiBRMMePerkushtim = this.CalculateBRM(payload.Gjinia, payload.Mosha, payload.Gjatesia, payload.Pesha, payload.Aktiviteti, payload.Perkushtimi);
            return this.getShujtat(payload, rezultatiBRMMePerkushtim);
            //return _context.Ushqimis.Where(x => x.ShujtaId == Convert.ToInt32(payload.CheckArray[0])).ToList();
        }

        private List<List<Ushqimi>> getShujtat(PayLoadDTO payload, double rezultatiBRM)
        {
            List<Ushqimi> breakfastsToReturn = new List<Ushqimi>();
            List<Ushqimi> lunchesToReturn = new List<Ushqimi>();
            List<Ushqimi> dinnersToReturn = new List<Ushqimi>();
            List<List<Ushqimi>> listToReturn = new List<List<Ushqimi>>(new List<Ushqimi>[3]);
            var qellimiDietes = payload.Qellimi;
            var mengjes = 0;
            var dreka = 0;
            var dreka2 = 0;
            var darka = 0;
            var darka2 = 0;
            int count = 0;
           
            if (qellimiDietes == "HeqePeshe")
            {
                rezultatiBRM = rezultatiBRM - Convert.ToInt32(payload.Sasia);
                var qellimiRez = Math.Floor(rezultatiBRM);
                switch (Convert.ToInt32(payload.NrShujtave))
                {

                    case 1:
                        mengjes = (int)Math.Floor(qellimiRez * 0.4);
                        dreka = (int)Math.Floor(qellimiRez * 0.6);

                        if (Convert.ToInt32(payload.Kohezgjatja) == 1)
                        {
                            while (count < 7)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 2)
                        {
                            while (count < 14)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 3)
                        {
                            while (count < 30)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));

                                count++;
                            }
                        }
                        break;
                    case 2:
                        mengjes = (int)Math.Floor(qellimiRez * 0.3);
                        dreka = (int)Math.Floor(qellimiRez * 0.4);
                        darka = (int)Math.Floor(qellimiRez * 0.3);
                        if (Convert.ToInt32(payload.Kohezgjatja) == 1)
                        {
                            while (count < 7)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 2)
                        {
                            while (count < 14)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 3)
                        {
                            while (count < 30)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        break;
                    case 3:
                        mengjes = (int)Math.Floor(qellimiRez * 0.2);
                        dreka = (int)Math.Floor(qellimiRez * 0.3);
                        dreka2 = (int)Math.Floor(qellimiRez * 0.3);
                        darka = (int)Math.Floor(qellimiRez * 0.2);
                        if (Convert.ToInt32(payload.Kohezgjatja) == 1)
                        {
                            while (count < 7)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 2)
                        {
                            while (count < 14)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 3)
                        {
                            while (count < 30)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        break;
                }
            }
            if (payload.Qellimi == "ShtojPeshe")
            {
                rezultatiBRM = rezultatiBRM + Convert.ToInt32(payload.Sasia);
                var qellimiRezz = Math.Floor(rezultatiBRM);

                switch (Convert.ToInt32(payload.NrShujtave))
                {
                    case 1:
                        mengjes = (int)Math.Floor(qellimiRezz * 0.3);
                        dreka = (int)Math.Floor(qellimiRezz * 0.4);
                        darka = (int)Math.Floor(qellimiRezz * 0.3);
                        if (Convert.ToInt32(payload.Kohezgjatja) == 1)
                        {
                            while (count < 7)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 2)
                        {
                            while (count < 14)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 3)
                        {
                            while (count < 30)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        break;
                    case 2:
                        mengjes = (int)Math.Floor(qellimiRezz * 0.2);
                        dreka = (int)Math.Floor(qellimiRezz * 0.3);
                        dreka2 = (int)Math.Floor(qellimiRezz * 0.3);
                        darka = (int)Math.Floor(qellimiRezz * 0.2);
                        if (Convert.ToInt32(payload.Kohezgjatja) == 1)
                        {
                            while (count < 7)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 2)
                        {
                            while (count < 14)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 3)
                        {
                            while (count < 30)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));

                                count++;
                            }
                        }
                        break;
                    case 3:
                        mengjes = (int)Math.Floor(qellimiRezz * 0.2);
                        dreka = (int)Math.Floor(qellimiRezz * 0.2);
                        dreka2 = (int)Math.Floor(qellimiRezz * 0.2);
                        darka = (int)Math.Floor(qellimiRezz * 0.2);
                        darka2 = (int)Math.Floor(qellimiRezz * 0.2);
                        if (Convert.ToInt32(payload.Kohezgjatja) == 1)
                        {
                            while (count < 7)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka2));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 2)
                        {
                            while (count < 14)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka2));

                                count++;
                            }
                        }
                        if (Convert.ToInt32(payload.Kohezgjatja) == 3)
                        {
                            while (count < 30)
                            {
                                breakfastsToReturn.AddRange(getShujtaMengjes(mengjes));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka));
                                lunchesToReturn.AddRange(getShujtaDreke(dreka2));
                                dinnersToReturn.AddRange(getShujtaDarke(darka));
                                dinnersToReturn.AddRange(getShujtaDarke(darka2));

                                count++;
                            }
                        }
                        break;
                }
            }

            listToReturn[0] = breakfastsToReturn;
            listToReturn[1] = lunchesToReturn;
            listToReturn[2] = dinnersToReturn;

            return listToReturn;
        }
        private List<Ushqimi> getShujtaDarke(int darka)
        {
            var rand = new Random();
            var nrDarke = rand.Next(8, 15);
            return _mealsRepository.GetUshqimetDarke(darka, nrDarke);
        }

        private List<Ushqimi> getShujtaDreke(int dreka)
        {
            var rand = new Random();
            var nrDreke = rand.Next(1, 8);
            return _mealsRepository.GetUshqimetDreke(dreka, nrDreke);
        }

        private List<Ushqimi> getShujtaMengjes(int mengjes)
        {
            var rand = new Random();
            var nrMengjes = rand.Next(15, 18);
            return _mealsRepository.GetUshqimetMengjes(mengjes, nrMengjes);
        }

        private double CalculateBRM(string gjinia, int mosha, double gjatesia, double pesha, string aktiviteti, string perkushtimi)
        {
            var rez = 0f;
            mosha = mosha * 5;
            gjatesia = (float)(gjatesia * 6.25);
            pesha = (float)pesha * 10;
            int aktivitetiInt = Convert.ToInt32(aktiviteti);
            int perkushtimiInt = Convert.ToInt32(perkushtimi);

            switch (aktivitetiInt)
            {
                case 1:
                    rez = gjinia == "M" ? (float)((gjatesia + pesha - mosha + 5) * 1.200268637) : (float)((gjatesia + pesha - mosha - 161) * 1.200268637);
                    break;
                case 2:
                    rez = gjinia == "M" ? (float)((gjatesia + pesha - mosha + 5) * 1.374937842) : (float)((gjatesia + pesha - mosha - 161) * 1.374937842);
                    break;
                case 3:
                    rez = gjinia == "M" ? (float)((gjatesia + pesha - mosha + 5) * 1.465144392) : (float)((gjatesia + pesha - mosha - 161) * 1.465144392);
                    break;
                case 4:
                    rez = gjinia == "M" ? (float)((gjatesia + pesha - mosha + 5) * 1.55003358) : (float)((gjatesia + pesha - mosha - 161) * 1.55003358);
                    break;
                case 5:
                    rez = gjinia == "M" ? (float)((gjatesia + pesha - mosha + 5) * 1.725184688) : (float)((gjatesia + pesha - mosha - 161) * 1.725184688);
                    break;
                case 6:
                    rez = gjinia == "M" ? (float)((gjatesia + pesha - mosha + 5) * 1.899798522) : (float)((gjatesia + pesha - mosha - 161) * 1.899798522);
                    break;
            }

            switch (perkushtimiInt)
            {
                case 1:
                    rez = rez - 160;
                    break;
                case 2:
                    rez = rez - 260;
                    break;
                case 3:
                    rez = rez - 340;
                    break;
                case 4:
                    rez = rez - 420;
                    break;
                case 5:
                    rez = rez - 560;
                    break;
                default:
                    rez = rez - 0;
                    break;
            }

            return rez;

        }
    }
}
