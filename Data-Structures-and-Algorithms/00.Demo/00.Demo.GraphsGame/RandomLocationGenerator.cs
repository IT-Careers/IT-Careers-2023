﻿namespace _00.Demo.GraphsGame
{
    public class RandomLocationGenerator
    {
        private readonly HashSet<string> possibleLocations = new HashSet<string>(new string[]{
            "Capview", "Sandmouth", "Greenfield", "Fishbury", "Rosepool", 
            "Lawburgh", "Beachfolk", "Richville", "Queenscester", "Strongworth", 
            "Great Oakhampton", "Frostford", "Great Freepool", "South Eggmouth", 
            "Buoycester", "Duckcester", "Southworth Beach", "Wheelworth", "Bridgedale", 
            "Lexingview", "Gilbury", "Holtsborough", "Hapness", "Eggland", "Backburgh", 
            "Hambrough", "Angerland", "Springdale", "Medhampton", "Farmfield", "Bridgewich", 
            "Appleview", "Strongdale", "Great Southhampton", "Daykarta", "Buoycaster", "Sayworth", 
            "Waltville", "Hogdale", "East Sugardol", "Passburgh", "Winwich", "East Griffinbury", 
            "Fortmouth", "Chatdale", "Lunstead", "Hamborough", "Applehampton", "Southingness", "Hapborough", 
            "Wingby", "South Highfield", "West Chatdol", "Kingmouth", "Great Melburg", "Postworth", 
            "Mannorburgh", "Auburgh City", "Great Valenwich", "Hardford", "Great Westtown", "Cloudstead City", 
            "Maybrough Park", "South Pineness", "Mayby", "Manmouth", "Fortfolk", "West Lunley", "Angerpool", 
            "Transstead", "Winterstead", "Pineport", "Westbrough", "Springland", "East Transville", "Medton", 
            "Dodgebrough", "Freebury", "Factford", "Springmouth", "Waltdale", "Weirstead Park", "Hardby", 
            "Seaburgh", "Sageford", "Bayfield", "Fairburg", "Wheelkarta", "Richbrough", "Princeness", 
            "Southingfield", "New Redby", "Capley", "Springside Falls", "Applewich", "Auford", 
            "East Hosham", "Seatown", "Riverpool", "Lunafield", "Cloudbury", "New Baycester", 
            "Stoneport", "North Parkton", "Gilview", "North Waltbury", "Sageford", "Valencester", 
            "West Juldale", "Rockbury", "Wingworth", "Wheelworth", "East Greendale", "Backville Park", 
            "Backbury Hills", "Oakburg", "Fayville", "West Bridgeness", "Great Southton", "West Weirfield",
            "Seafolk", "Frostgrad", "Bannhampton", "Griffinview", "Eggdol", "Ashcaster", "North Lexingcaster", 
            "East Hollowtown", "Seastead", "Hosland", "Sagecester", "Waltkarta", "Wheelpool", "Dodgeport Island", 
            "Mayworth", "East Transstead", "Beachgrad", "Costsside", "Lunwich", "East Frosttown", "Oakpool",
            "Eastborough", "Redworth Hills", "Hollowworth", "Bridgebrough", "Northgrad", "East Jamesburg", 
            "Hapstead", "Clamstead", "Duckburgh", "Norstead", "Mansdale", "Hospool", "Rockburgh", "Hamfolk", 
            "Fishburgh", "Maybrough City", "Foxham Island", "Backport", "Lawgrad", "Medstead", "West Mannormouth", 
            "Wincester", "Southingville", "Bridgestead", "Great Elburgh", "New Mannorport", 
            "Bridgeham", "Summerworth Island", "Jamescester", "South Sandborough", "Richview", "Eggmouth", 
            "South Norham", "West Winterborough", "Springfield Park", "Hardgrad", "Angercester", "Applewich Beach", 
            "Factkarta", "Fortview", "Dayfolk", "Buoybury", "Elworth Falls", "Melport Falls", "Fairgrad Hills", 
            "Hollowhampton City", "Fairville", "Capford", "Passpool Falls", "Fauxbrough", "Rosemouth", "Foxness", 
            "South Queensdale", "Ashley", "Jamesdale", "Frostley", "Griffinbrough", "Rockview", "Redcaster",
            "Great Fortside", "Farmkarta", "Sweetness", "Saltview", "South Summerfolk", "New Sweetkarta", "Parkcester", 
            "Pinehampton", "Freefolk", "Richmouth", "Goldwich", "Capburg", "Wingmouth", "Middleview", "Wheelworth", 
            "Hapstead", "Julstead", "Snowley", "Fauxdol", "Cruxbury", "Rockport", "Bannton", "Rosegrad", "Stoneley", 
            "Great Mannorside", "Lawford", "Casterwich City", "Sweetbury", "Bridgemouth", "Foxton Island", "Gilford", 
            "Fauxview", "Sugargrad", "Gilfield", "Elworth", "South Sayton", "West Northton", "Queensby", 
            "Parkstead", "Lunagrad", "Waterdale", "Waterville", "Fauxwich", "Julburgh", "Factburg", "Winside", 
            "Seaside", "Sugarbrough", "Bellhampton", "Springley", "Frostkarta Park", "Valenbrough", "Mansbrough", 
            "Profolk", "Eggdol", "Winkarta", "Rosecester Beach", "Cloudley", "Farmingcester", "Goldford", "Lexingfield",
            "Aelworth", "Dayville", "Frostcaster", "Saybury", "Fayburg Falls", "Middleville", "Norstead", "Rockstead Hills",
            "Weirview", "Pineborough", "Augrad Park", "Highburgh", "New Kettlecaster", "Medkarta", "Holtsburgh", 
            "Riverland City", "Richbury", "Foxbury", "West Springham", "Backdale", "Middlebrough Falls", "Hapdol", 
            "Strongburg City", "Weirview", "South Chatburgh", "West Weirdol", "Valenley", "Strongcester", "South Winview", 
            "Aelham", "Foxfield", "Casterwich", "Gilland", "Winton", "Nordale", "Greenburg Beach", "Sweetbury", "Highside",
            "Postbrough", "Sandfield", "New Waterdale", "Meddol", "Saltfield", "Duckville", "Watercaster", "Backford", 
            "Backbury Beach", "Aelpool City", "Farmingport Park", "North Fayburgh", 
            "Hapness", "Eggbrough", "Julworth", "Winby", "Cloudbury", "East Mannorwich", "Oakmouth", "Richkarta", 
            "Saltness", "East Dayfield", "Luntown", "Wheelport", "Waltness", "Millside", "Kettleville", "Sugarview",
            "Wingstead", "Highside", "North Bayburg", "Pineham Park", "North Starside", "Hallport", "Farmbury", 
            "Postview", "Saltdol City", "Northburgh", "Buoystead", "Audol", "Snowburg", "Frostville", "Queensmouth", 
            "Transville", "East Pailland", "Springfolk", "Sugarkarta Hills", "Lawfield", "West Griffinbrough", "Buoyby", 
            "Postmouth", "Farmtown", "Foxville Falls", "New Rockmouth", "Holtsby", "Kingham Park", "Watermouth", "East Waterham",
            "Angerstead", "Lexingmouth", "Southton", "Maybrough", "New Stardale", "Casterville", "Pailham", "Roseborough",
            "Sandburgh", "Sagedale", "Transburgh", "Casterford", "Mandale", "Coststown", "Hosley Beach", "Bellland", "Casterpool",
            "Julkarta", "Castertown", "Fairport Beach", "Stonecester", "Duckness", "Cruxtown", "New Griffinbrough", "Hardburgh",
            "Capbrough", "Angerville", "Elhampton", "Summercester", "Factview", "Aelmouth", "New Frostworth", "Strongcaster", 
            "Aelham", "Fairport", "Saltby", "Sweetkarta", "Lunaburgh", "Julburg", "Farmingpool Falls", "Readingville", "Angerham", 
            "Eastport", "Southburgh", "Fairside", "Fortburg", "Seagrad", "Farmstead", "Maydol", "Goldville", "Griffinkarta", 
            "Norview City", "East Casterside", "Medfolk Island", "Dayham", "Stoneby", "Procester", "Parkbrough", "Lexingdale",
            "Beachcester Beach", "Melford", "Clamport", "Sandkarta Falls", "Snowbury", "Eastfolk", "Passtown", "Eastville",
            "Tallburgh", "Emercaster", "New Riverworth", "Postport", "Goldbrough", "Redkarta", "Costsham", "Winworth", "Kettlepool",
            "Capstead", "Dodgedol", "Gilcester", "Greendol", "South Sagecaster", "Bridgefolk", "Valendol", "Springland", 
            "Summerness", "New Weircaster", "Waltstead", "Clamville", "West Postby", "Eggcester", "Weirbury", "East Hogham",
            "Farmingburgh", "Strongfolk", "Freeland", "Greendol Park", "Melworth", "New Fairley", "Farmburg", "Norbury", 
            "Hollowville", "Bellbrough", "Jameston", "South Summertown", "Pineburgh", "Chatmouth", "Snowness", "Eggby", 
            "Hogness", "Transville", "Queensgrad", "Fortworth", "Dodgeburgh", "Pinedale", "Sweetcaster", "Kettleland", 
            "Strongfield Park", "West Kingport", "Medfolk", "Wheelpool", "Kingness", "Fishby", "New Farmingburgh", 
            "Lunaworth", "Lexingwich", "Baydol", "Cloudkarta Park", "Massburg", "Wheelburg", "West Bannfield", "Highcaster", 
            "New Mancester", "Greenwich", "Great Pailgrad", "Farmingside", "Mannortown", "Postburgh", "South Maydol", 
            "South Dodgedol", "Snowgrad", "Sweetdale", "Manland", "Hallstead", "Eggbrough", "Dodgefield", "Great Valenkarta",
            "Middleburgh", "Stonefolk", "Highton", "Oakburgh", "Eggport", "New Stoneford", "East Bellness", "Costscaster", 
            "Buoyborough", "Massville", "Angerdale Park", "New Winterside", "Strongwich Park", "Haptown", "Fauxfield", 
            "Riverfolk", "Holtsbrough", "Great Capborough", "Southstead", "Eastfield", "West Foxbrough", "Eggdol", 
            "Springside", "Mannorcester", "Fishhampton", "Skilldale", "Seatown", "Fairworth", "West Seagrad", 
            "Watertown City", "Casterwich", "Oakness", "Roseburgh", "Pineby", "Waterton", "Massness Park", 
            "Kettlestead", "Hollowgrad Beach", "Eggville", "Hampool", "Backside", "Goldgrad", "Oakley", "Valenburg", 
            "Backton", "Foxdale", "Southfield", "Casterfield Hills", "Faycester", "Costsfolk", "Sandborough",
            "West Elport", "Sandfield", "Hapham", "Appleworth Island", "Melbury", "East Dayness", "Mannorby",
            "South Freeburgh", "Mannorcester", "Oakland", "Bannmouth", "Emercaster", "Jameston Park", "Hosdale", 
            "West Sandview", "Sweetpool", "Bridgeburg Island", "Mayville", "New Sandcaster", "Harddol", 
            "Transdol Hills", "Promouth", "Southingworth", "Ashside Hills", "Rosegrad", 
            "Bayfolk", "Watercaster Hills", "Fauxdale", "Eggburg", 
            "Frostton", "Summerburg", "Hallmouth Beach", "North Factcester", "Buoybury", 
            "Skillness Island", "South Queensley", "Sugarworth", "Lunaland", "Proton", "Weirland", 
            "Backbrough", "Kingby", "Prodol", "Fishfolk", "Manscaster", "Chatport", "Emerview", "East Passtown", 
            "Saltworth", "Fortfield", "Weirbury", "Wingview", "Hostown", "South Northdol", "Snowmouth", "Capborough",
            "South Fishburg", "Sweetburg", "Banntown", "Millness", "South Fortham", "Ashcaster", "Seastead City", 
            "Backton Falls", "Passbury", "East Proford", "Medburgh", "Clamdol", "Summergrad", "New Emerburgh", "Wheelworth", 
            "Winterland", "Waterworth", "Bannbury", "North Sayport", "Hardbrough City", "Postmouth", "Baypool", "East Dayview", 
            "Winterport", "Southingby Park", "Strongview", "Norhampton", "North Holtsview", "Great Lawbrough", "Transbrough", 
            "Middleby City", "East Waterby", "Lunkarta", "Freetown", "Baystead", "Dodgedale", "Pailton", "Jamesdale", "Fishland", 
            "Applepool", "Cruxburg", "Massworth Beach", "Dodgeham", "Bridgeport Hills", "South Luncester", "Valendale", "Rockside",
            "Highville Beach", "Pineford", "Summerfield City", "Fauxworth Island", "Julburg", "Cruxford", "Chatside", "Westburg", 
            "Melworth", "Winwich", "Waterness", "Eggpool", "Hapfolk", "Oakkarta", "Fishpool", "Wintown", "Frostham", "Holtsland",
            "Oakport", "Aelhampton", "Farmingness", "Austead", "Eastkarta", "Griffincester", "Manburgh Falls", "Wheelton",
            "Saltville", "Weircester", "Chatfolk", "Lexingpool", "Waltville Hills", "Faycester", "Pinehampton", "South Paildale",
            "Saltburg", "New Daycester", "Strongbury", "Hogford", "Farmingfield", "Beachworth Beach", "Transstead", "Ashdol", 
            "Sweetdale", "Mandale", "Fishstead", "Griffinbrough", "Bellcaster", "Cloudley", "Transton", "Weirby", "Stonestead",
            "South Chatton", "Sweetview", "Freeley", "Richness", "Summerham", "Appleworth", "Winterley", "Mannorby", "Dayburgh", 
            "Chatwich", "New Backbrough", "New Northfolk", "Strongstead", "Aelpool", "Fauxburg", "Aelfield", "New Pineview", 
            "Winterport", "Angerborough", "Elby", "Stronghampton", "West Strongdale", "Valenpool", "Starburgh", "Mannortown",
            "West Seaham", "Kingport", "South Costsgrad", "Seagrad", "Dodgefolk", "Hogford", "Foxworth", "Forttown Hills", 
            "East Winterton", "Elford Park", "Saywich Hills", "Farmdale Island", "Norford", "Pailgrad", "West Melland", 
            "Clamcester", "Bridgecaster", "South Passbury", "Rockland", "Readingland", "Auport", "Strongville", "Sayburg", 
            "Rosegrad", "Kettleford", "Lunafield", "Lunamouth", "Clamville", "Frostgrad City", "Waltham", "Seapool", "Great Hapby", 
            "Pailburg Beach", "Hamford", "Westmouth", "Hardness", "East Winside", "Queensford", "Fairville Park", "Chatness",
            "Skillmouth", "Ashburg", "Dodgehampton", "Farmley", "North Greendale", "Sayton", "Hoston", "South Richview", "Sealey",
            "Waterdale", "Watercaster", "Sandton", "Waltgrad", "Harddale", "Lunafolk", "North Pailford", "Audale", "Princeport", 
            "East Beachwich", "Winpool", "Fayford", "New Cruxborough", "Queenswich", "Redkarta", "Cruxkarta", "Lunfolk",
            "East Eastside", "Frostbury", "Harddol",
            "Highcester", "Jamesburgh Falls", "Clamfolk", "South Casterhampton", "Pailfield", "Southingstead", "Richcester",
            "West Wingworth", "Snowgrad", "Springborough Beach", "Parkworth", "Lunastead Beach", "Gilpool Hills", "Ashley", 
            "Factside", "Wingport", "Pailton", "Bridgebury", "Meldale", "Faircester", "Dayham", "Appleford", "North Farmstead",
            "Massville", "Farmdale", "Gilbrough", "Great Lunville", "Stonehampton", "New Lunabury", "Faykarta", "Pineley", 
            "Buoybury", "Great Springtown", "Transville Hills", "South Fayland", "Kingdale Beach", "Griffinland", "Skillgrad", 
            "Readinggrad", "Beachpool", "Great Queensfolk", "Middlecaster", "Pailby", "Great Applefield", "Haphampton Beach", 
            "Lunadol", "Valendol", "Ashdale", "Winburg", "Manford", "Great Hardwich", "Appleborough", "Buoywich", "Passburg", 
            "Eastfolk", "Backford City", "Fishkarta", "Aelworth Falls", "South Sandkarta", "Northcaster", "Greencester", 
            "Hammouth", "Greendol", "Millborough Park", "Roseby", "Starville Hills", "New Bridgeness", "Capton", "Aelwich", 
            "Rosecester", "South Hollowside", "Lunaside", "Snowfield", "Starford", "North Chatfolk", "Summerkarta", "Hightown", 
            "Buoyford", "Summerborough", "Postside", "Emerstead", "Hardcester", "Foxby", "Wheelfield", "Snowham", "Readingpool", 
            "Gilborough", "Gilbury Beach", "Melfolk", "North Goldby", "Medby", "Sayton", "Millwich", "Princedol", "Postburgh Park", 
            "Wheelside", "Passley", "Auburg", "Readingburg Hills", "Melborough", "Middleburgh", "Great Springport", 
            "Eastley", "Foxstead", "Highpool", "Seabrough", "Kingstead", "Bridgemouth", "Griffinton", "Goldcaster", "Roseport",
            "Griffinville", "Snowport", "Springford", "Maycester", "Stoneham", "Griffinview", "Saltport", "Beachborough Beach", 
            "Frostcester", "Strongburgh Park", "Aufolk", "Hoghampton", 
            "Lawford Beach", "Costskarta", "Sayside", "Sandborough", "Fortcaster", "West Cruxfolk", "Skilldol Beach",
            "Sageborough Beach", "Great Stonewich", "Westville", "Farmingtown", "Waltton", "East Daywich", "Ashburg", 
            "Redmouth", "East Lunaness", "Pinedol", "Sageby", "Southingley", "Bannford", "Capstead", "East Capbrough", 
            "Elmouth", "Farmingcaster", "Queenspool", "Daymouth", "Manstown", "Great Hospool", "Parkbury Park", 
            "Hosville", "East Ashmouth", "Fauxport", "Great Fortwich", "Hardview", "Highcester", "New Elwich",
            "Fauxfield", "South Melby", "North Gildol", "Hollowburgh", "Backford Island", "Weirkarta Beach", 
            "Sweetdol Beach", "Parkhampton", "Chatstead", "Frostland", "Costsmouth", "Strongpool", "Great Hamhampton", 
            "Sayby", "Factstead", "North Backville", "Great Fayview", "Saltside", "Pailmouth", "Cloudport", 
            "East Highbury", "Applecaster Park", "Readingcester", "Riverdale Island", "Probury", "Propool", "Seaside", 
            "West Audol", "Casterbury", "Frosttown", "Factby", "Winhampton Island", "Julworth", "Valenkarta", "Gildale", 
            "Chatgrad", "Hosford", "Fairfolk", "Beachville"
        });

        public List<string> GetRandomLocations(int count)
        {
            List<string> results = new List<string>();

            foreach (var item in possibleLocations)
            {
                if (count == 0) break;

                results.Add(item);

                count--;
            }

            foreach (var item in results)
            {
                this.possibleLocations.Remove(item);
            }

            return results;
        }
    }
}
