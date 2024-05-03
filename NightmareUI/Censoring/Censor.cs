﻿using ECommons;
using Lumina.Misc;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI.Censoring;
public static class Censor
{
		private static readonly FrozenDictionary<CensorType, string[]> CensorData = new Dictionary<CensorType, string[]>()
		{
				[CensorType.Animal] = ["Dog", "Cow", "Cat", "Horse", "Donkey", "Tiger", "Lion", "Panther", "Leopard", "Cheetah", "Bear", "Elephant", "Turtle", "Tortoise", "Crocodile", "Rabbit", "Porcupine", "Hare", "Hen", "Pigeon", "Albatross", "Crow", "Fish", "Dolphin", "Frog", "Whale", "Alligator", "Eagle", "Ostrich", "Fox", "Goat", "Jackal", "Emu", "Armadillo", "Eel", "Goose", "Wolf", "Beagle", "Gorilla", "Chimpanzee", "Monkey", "Beaver", "Orangutan", "Antelope", "Bat", "Badger", "Giraffe", "Hamster", "Cobra", "Camel", "Hawk", "Deer", "Chameleon", "Hippopotamus", "Jaguar", "Chihuahua", "Ibex", "Lizard", "Koala", "Kangaroo", "Iguana", "Llama", "Chinchillas", "Dodo", "Jellyfish", "Rhinoceros", "Hedgehog", "Zebra", "Possum", "Wombat", "Bison", "Bull", "Buffalo", "Sheep", "Meerkat", "Mouse", "Otter", "Sloth", "Owl", "Vulture", "Flamingo", "Racoon", "Mole", "Duck", "Swan", "Lynx", "Elk", "Boar", "Lemur", "Mule", "Baboon", "Mammoth", "Rat", "Snake", "Peacock", "Aardvark", "Aardwolf", "Abyssinian", "Addax", "Affenpinscher", "Agouti", "Aidi", "Ainu", "Airedoodle", "Akbash", "Akita", "Albertonectes", "Allosaurus", "Alpaca", "Alusky", "Amargasaurus", "Amberjack", "Anaconda", "Anchovies", "Andrewsarchus", "Angelfish", "Angelshark", "Anglerfish", "Anhinga", "Anomalocaris", "Ant", "Anteater", "Anteosaurus", "Ape", "Arambourgiania", "Arapaima", "Archaeoindris", "Archaeopteryx", "Archaeotherium", "Archerfish", "Arctodus", "Arctotherium", "Argentinosaurus", "Armyworm", "Arsinoitherium", "Arthropleura", "Asp", "Aurochs", "Aussiedoodle", "Aussiedor", "Aussiepom", "Australopithecus", "Avocet", "Axolotl", "Azawakh", "Babirusa", "Baiji", "Balinese", "Bandicoot", "Barb", "Barbet", "Barinasuchus", "Barnacle", "Barnevelder", "Barosaurus", "Barracuda", "Barylambda", "Basilosaurus", "Bass", "Bassador", "Bassetoodle", "Batfish", "Baya", "Beabull", "Beagador", "Beaglier", "Beago", "Beaski", "Beauceron", "Bee", "Beefalo", "Beetle", "Bergamasco", "Bernedoodle", "Bichir", "Bichpoo", "Bilby", "Binturong", "Bird", "Birman", "Blobfish", "Bloodhound", "Blowfly", "Bluefish", "Bluegill", "Boas", "Bobcat", "Bobolink", "Boerboel", "Boggle", "Boiga", "Bombay", "Bonefish", "Bongo", "Bonobo", "Booby", "Boomslang", "Borador", "Bordoodle", "Borkie", "Boskimo", "Bowfin", "Boxachi", "Boxador", "Boxerdoodle", "Boxfish", "Boxsky", "Boxweiler", "Brachiosaurus", "Briard", "Brittany", "Brontosaurus", "Brug", "Budgerigar", "Bullboxer", "Bulldog", "Bullfrog", "Bullmastiff", "Bullsnake", "Bumblebee", "Burmese", "Butterfly", "Caecilian", "Caiman", "Cantil", "Canvasback", "Capuchin", "Capybara", "Caracal", "Cardinal", "Caribou", "Carp", "Cascabel", "Cassowary", "Caterpillar", "Catfish", "Cavador", "Cavapoo", "Centipede", "Cephalaspis", "Ceratopsian", "Ceratosaurus", "Chamois", "Chartreux", "Cheagle", "Chickadee", "Chicken", "Chigger", "Chilesaurus", "Chimaera", "Chinchilla", "Chinook", "Chipit", "Chipmunk", "Chipoo", "Chiton", "Chiweenie", "Chorkie", "Chusky", "Cicada", "Cichlid", "Clownfish", "Coati", "Cobras", "Cockalier", "Cockapoo", "Cockatiel", "Cockatoo", "Cockle", "Cockroach", "Codfish", "Coelacanth", "Collie", "Compsognathus", "Conure", "Copperhead", "Coral", "Corella", "Corgidor", "Corgipoo", "Corkie", "Cormorant", "Coryphodon", "Cottonmouth", "Cougar", "Coyote", "Crab", "Crane", "Crayfish", "Cricket", "Crocodylomorph", "Cryolophosaurus", "Cuckoo", "Cuttlefish", "Dachsador", "Dachshund", "Daeodon", "Dalmadoodle", "Dalmador", "Dalmatian", "Damselfish", "Daniff", "Danios", "Daug", "Deinocheirus", "Deinosuchus", "Desmostylus", "Dhole", "Dickcissel", "Dickinsonia", "Dilophosaurus", "Dimetrodon", "Dingo", "Dinocrocuta", "Dinofelis", "Dinopithecus", "Dinosaurs", "Diplodocus", "Diprotodon", "Discus", "Dobsonfly", "Doedicurus", "Dorgi", "Dorkie", "Dormouse", "Douc", "Doxiepoo", "Doxle", "Dragonfish", "Dragonfly", "Dreadnoughtus", "Drever", "Dugong", "Dunker", "Dunkleosteus", "Dunnock", "Earthworm", "Earwig", "Echidna", "Eelpout", "Egret", "Eider", "Eland", "Elasmosaurus", "Elasmotherium", "Embolotherium", "Epidexipteryx", "Ermine", "Eryops", "Escolar", "Eskipoo", "Euoplocephalus", "Eurasier", "Eurypterus", "Falcon", "Fangtooth", "Feist", "Ferret", "Finch", "Firefly", "Fisher", "Flea", "Flounder", "Fly", "Flycatcher", "Fossa", "Frenchton", "Frengle", "Frigatebird", "Frogfish", "Frug", "Gadwall", "Gar", "Gastornis", "Gazelle", "Gecko", "Genet", "Gerbil", "Gharial", "Gibbon", "Gigantopithecus", "Glechon", "Glowworm", "Gnat", "Goberian", "Goldador", "Goldcrest", "Goldendoodle", "Goldfish", "Gollie", "Gomphotherium", "Gopher", "Goral", "Gorgosaurus", "Goshawk", "Gourami", "Grasshopper", "Grebe", "Greyhound", "Griffonshire", "Groenendael", "Grouper", "Grouse", "Grunion", "Guppy", "Haddock", "Hagfish", "Haikouichthys", "Hainosaurus", "Halibut", "Hallucigenia", "Harrier", "Hartebeest", "Hatzegopteryx", "Havamalt", "Havanese", "Havapoo", "Havashire", "Havashu", "Helicoprion", "Hellbender", "Heron", "Herrerasaurus", "Herring", "Himalayan", "Hogfish", "Hokkaido", "Hoopoe", "Horgi", "Hornbill", "Hornet", "Horsefly", "Housefly", "Hovasaurus", "Hovawart", "Human", "Hummingbird", "Huntaway", "Huskador", "Huskita", "Husky", "Huskydoodle", "Hyaenodon", "Hyena", "Ibis", "Icadyptes", "Ichthyosaurus", "Ichthyostega", "Iguanodon", "Impala", "Inchworm", "Indri", "Insect", "Insects", "Jabiru", "Jacana", "Jackabee", "Jackdaw", "Jackrabbit", "Jagdterrier", "Javanese", "Jerboa", "Junglefowl", "Kagu", "Kakapo", "Katydid", "Kea", "Keagle", "Keelback", "Keeshond", "Kestrel", "Kiang", "Killdeer", "Killifish", "Kingfisher", "Kingklip", "Kinkajou", "Kishu", "Kiwi", "Klipspringer", "Knifefish", "Kodkod", "Komondor", "Kooikerhondje", "Koolie", "Kouprey", "Kowari", "Krait", "Krill", "Kudu", "Kuvasz", "Labahoula", "Labmaraner", "Labrabull", "Labradane", "Labradoodle", "Labraheeler", "Labrottie", "Ladybug", "Ladyfish", "Lamprey", "Lancetfish", "Leech", "Leedsichthys", "Lemming", "Leonberger", "Leptocephalus", "Lhasapoo", "Liger", "Limpet", "Linnet", "Lionfish", "Liopleurodon", "Livyatan", "Lizardfish", "Loach", "Lobster", "Locust", "Lorikeet", "Loris", "Lowchen", "Lumpfish", "Lungfish", "Lurcher", "Lyrebird", "Lystrosaurus", "Macaque", "Macaw", "Machaeroides", "Macrauchenia", "Maggot", "Magpie", "Magyarosaurus", "Maiasaura", "Malchi", "Mallard", "Malteagle", "Maltese", "Maltipom", "Maltipoo", "Mamba", "Manatee", "Mandrill", "Margay", "Markhor", "Marmoset", "Marmot", "Masiakasaurus", "Massasauga", "Mastador", "Mastiff", "Mauzer", "Mayfly", "Meagle", "Mealybug", "Megalania", "Megalochelys", "Megalodon", "Meganeura", "Megatherium", "Meiolania", "Merganser", "Microraptor", "Miki", "Milkfish", "Millipede", "Mink", "Mockingbird", "Mojarra", "Mollusk", "Molly", "Mongoose", "Mongrel", "Monkfish", "Moorhen", "Moose", "Morkie", "Mosasaurus", "Mosquito", "Moth", "Mudi", "Mudpuppy", "Mudskipper", "Muntjac", "Muskox", "Muskrat", "Muttaburrasaurus", "Nabarlek", "Naegleria", "Narwhal", "Natterjack", "Nautilus", "Neanderthal", "Nebelung", "Needlefish", "Nematode", "Newfoundland", "Newfypoo", "Newt", "Nightingale", "Nightjar", "Nilgai", "Norrbottenspets", "Nudibranch", "Numbat", "Nuralagus", "Nuthatch", "Nutria", "Nyala", "Oarfish", "Ocelot", "Octopus", "Oilfish", "Okapi", "Olingo", "Olm", "Onager", "Opabinia", "Opah", "Opossum", "Oribi", "Ornithocheirus", "Ornithomimus", "Osprey", "Ostracod", "Otterhound", "Ovenbird", "Oviraptor", "Ox", "Oxpecker", "Oyster", "Pachycephalosaurus", "Paddlefish", "Pademelon", "Palaeophis", "Paleoparadoxia", "Pangolin", "Papillon", "Parakeet", "Parasaurolophus", "Parrot", "Parrotfish", "Parrotlet", "Partridge", "Patagotitan", "Peagle", "Peekapoo", "Pekingese", "Pelagornis", "Pelagornithidae", "Pelican", "Pelycosaurs", "Penguin", "Persian", "Pheasant", "Phorusrhacos", "Phytosaurs", "Pig", "Pika", "Pinfish", "Pipefish", "Piranha", "Pitador", "Pitsky", "Platybelodon", "Platypus", "Plesiosaur", "Pliosaur", "Pointer", "Polacanthus", "Polecat", "Pomapoo", "Pomchi", "Pomeagle", "Pomeranian", "Pomsky", "Poochon", "Poodle", "Poogle", "Porcupinefish", "Potoo", "Potoroo", "Prawn", "Procoptodon", "Pronghorn", "Psittacosaurus", "Pteranodon", "Pterodactyl", "Pudelpointer", "Puertasaurus", "Pufferfish", "Puffin", "Pug", "Pugapoo", "Puggle", "Pugshire", "Puli", "Puma", "Pumi", "Purussaurus", "Pyrador", "Pyredoodle", "Pyrosome", "Python", "Quagga", "Quail", "Quetzal", "Quokka", "Quoll", "Raccoon", "Ragamuffin", "Ragdoll", "Raggle", "Rattlesnake", "Redstart", "Reindeer", "Repenomamus", "Rhamphosuchus", "Rhea", "Roadrunner", "Robin", "Rockfish", "Rodents", "Rooster", "Rotterman", "Rottle", "Rottsky", "Rottweiler", "Sable", "Saiga", "Sailfish", "Salamander", "Salmon", "Saluki", "Sambar", "Samoyed", "Sandpiper", "Sandworm", "Saola", "Sapsali", "Sarcosuchus", "Sardines", "Sarkastodon", "Sarplaninac", "Sauropoda", "Sawfish", "Scallops", "Schapendoes", "Schipperke", "Schneagle", "Schnoodle", "Scorpion", "Sculpin", "Scutosaurus", "Seagull", "Seahorse", "Seal", "Serval", "Seymouria", "Shantungosaurus", "Shark", "Shastasaurus", "Sheepadoodle", "Shepadoodle", "Shepkita", "Shepweiler", "Shichi", "Shikoku", "Shiranian", "Shollie", "Shrew", "Shrimp", "Siamese", "Siberian", "Siberpoo", "Sidewinder", "Simbakubwa", "Sinosauropteryx", "Sivatherium", "Skua", "Skunk", "Slug", "Smilosuchus", "Snail", "Snailfish", "Snorkie", "Snowshoe", "Somali", "Spalax", "Spanador", "Sparrow", "Sparrowhawk", "Sphynx", "Spider", "Spinosaurus", "Sponge", "Springador", "Springbok", "Springerdoodle", "Squid", "Squirrel", "Squirrelfish", "Stabyhoun", "Starfish", "Stingray", "Stoat", "Stonechat", "Stonefish", "Stork", "Stromatolite", "Stupendemys", "Sturgeon", "Styracosaurus", "Suchomimus", "Suckerfish", "Supersaurus", "Superworm", "Surgeonfish", "Swallow", "Swordfish", "Taipan", "Takin", "Tamarin", "Tamaskan", "Tang", "Tapir", "Tarantula", "Tarbosaurus", "Tarpon", "Tarsier", "Tenrec", "Termite", "Terrier", "Tetra", "Thalassomedon", "Thanatosdrakon", "Therizinosaurus", "Theropod", "Thrush", "Thylacoleo", "Thylacosmilus", "Tick", "Tiffany", "Tiktaalik", "Titanoboa", "Titanosaur", "Toadfish", "Torkie", "Tornjak", "Tosa", "Toucan", "Towhee", "Toxodon", "Treecreeper", "Treehopper", "Triggerfish", "Troodon", "Tropicbird", "Trout", "Tuatara", "Tuna", "Turaco", "Turkey", "Turnspit", "Turtles", "Tusoteuthis", "Tylosaurus", "Uakari", "Uguisu", "Uintatherium", "Umbrellabird", "Urial", "Utonagan", "Vaquita", "Veery", "Vegavis", "Velociraptor", "Vicuña", "Vinegaroon", "Viper", "Viperfish", "Vizsla", "Vole", "Waimanu", "Wallaby", "Walrus", "Warbler", "Warthog", "Wasp", "Waterbuck", "Weasel", "Weimaraner", "Weimardoodle", "Westiepoo", "Whimbrel", "Whinchat", "Whippet", "Whiting", "Whoodle", "Wildebeest", "Wiwaxia", "Wolffish", "Wolverine", "Woodlouse", "Woodpecker", "Woodrat", "Worm", "Wrasse", "Wryneck", "Xenacanthus", "Xenoceratops", "Xenoposeidon", "Xenotarsosaurus", "Xerus", "Xiaosaurus", "Xiaotingia", "Xiongguanlong", "Xiphactinus", "Xoloitzcuintli", "Yabby", "Yak", "Yarara", "Yellowhammer", "Yellowthroat", "Yoranian", "Yorkiepoo", "Zebu"],

				[CensorType.Adjective] = ["Attractive", "Bald", "Beautiful", "Chubby", "Clean", "Dazzling", "Drab", "Elegant", "Fancy", "Fit", "Flabby", "Glamorous", "Gorgeous", "Handsome", "Long", "Magnificent", "Muscular", "Plain", "Plump", "Quaint", "Scruffy", "Shapely", "Short", "Skinny", "Stocky", "Unkempt", "Unsightly", "Ambitious", "Amiable", "Analytical", "Assertive", "Authentic", "Bold", "Calm", "Charismatic", "Charming", "Cheerful", "Compassionate", "Confident", "Conscientious", "Considerate", "Creative", "Curious", "Dependable", "Diligent", "Disciplined", "Easygoing", "Empathetic", "Enthusiastic", "Extraverted", "Flexible", "Friendly", "Generous", "Genuine", "Gracious", "Hardworking", "Honest", "Humble", "Independent", "Innovative", "Insightful", "Intelligent", "Kind", "Logical", "Loyal", "Optimistic", "Outgoing", "Passionate", "Patient", "Persistent", "Practical", "Rational", "Reliable", "Resourceful", "Responsible", "Stunning", "Striking", "Cute", "Pretty", "Radiant", "Athletic", "Fashionable", "Stylish", "Graceful", "Exquisite", "Alluring", "Smart", "Brilliant", "Wise", "Sharp", "Astute", "Perceptive", "Discerning", "Knowledgeable", "Learned", "Educated", "Intellectual", "Gifted", "Talented", "Imaginative", "Attentive", "Focused", "Concentrated", "Brave", "Sociable", "Decisive", "Determined", "Adaptable", "Energetic", "Forgiving", "Tolerant", "Versatile", "Caring", "Fearless", "Persevering", "Persuasive", "Sincere", "Thoughtful", "Trustworthy", "Understanding", "Witty", "Happy", "Sad", "Angry", "Fearful", "Anxious", "Excited", "Frustrated", "Nostalgic", "Hopeful", "Envious", "Jealous", "Surprised", "Disappointed", "Grateful", "Confused", "Content", "Lonely", "Joyful", "Melancholic", "Irritated", "Apprehensive", "Restless", "Ecstatic", "Distraught", "Panicked", "Annoyed", "Numb", "Scared", "Enraged", "Heartbroken", "Amused", "Overwhelmed", "Conflicted", "Peaceful", "Devastated", "Empowered", "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Pink", "Brown", "Gray", "Black", "White", "Silver", "Golden", "Turquoise", "Lavender", "Magenta", "Teal", "Indigo", "Large", "Small", "Tiny", "Petite", "Massive", "Gigantic", "Colossal", "Minuscule", "Tall", "Compact", "Thin", "Slim", "Bulky", "Narrow", "Wide", "Thick", "Fine", "Coarse", "Substantial", "Meager", "Oversized", "Undersized", "Roomy", "Snug", "Lanky", "Stubby"],

				[CensorType.World] = ["Albion", "Asgard", "Avalon", "Averoigne", "Azeroth", "Barsoom", "Darkover", "Deltora", "Dinotopia", "Discworld", "Dreamlands", "Earthsea", "Encantadia", "Equestria", "Eternia", "Etheria", "Filgaia", "Gielinor", "Glorantha", "Gor", "Greyhawk", "Halkeginia", "Hyrule", "Ivalice", "Lankhmar", "Melnibone", "Narnia", "Neverland", "Nirn", "Pellucidar", "Pern", "Prydain", "Spira", "Thedas", "Tyria", "Westeros", "Wonderland", "Xanth", "Devuniake", "Angbotain", "Warkinles", "Prisluake", "Spiunknds", "Dradevows", "Froprirth", "Warlosnse", "Kingollds", "Loskinake", "Losslurse", "Devfronds", "Quewarnds", "Golpoichy", "Warwarion", "Devlocsea", "Elvgolsle", "Prirotles", "Phosortum", "Loslosach", "Pholubnse", "Trowizrse", "Pholubalm", "Redsorest", "Spirotest", "Kinspisea", "Phosorory", "Losillsle", "Redlorlds", "Develdion", "Devunkory", "Witdeaxus", "Eldtrorse", "Locillnds", "Froqueion", "Elvfroane", "Angbotnet", "Trosoroon", "Elvwilows", "Fropoitry", "Troeldchy", "Locdraoon", "Angdevsle", "Elvkinles", "Warelvtum", "Warbrotum", "Phosluows", "Draelvder", "Trodrands", "Eldkinane", "Priangain", "Elvdevnet", "Deawitlds", "Draunkles", "Deaunkoon", "Devredout", "Quekinsea", "Kinfronet", "Spislunds", "Prilosean", "Kinwizean", "Anglocnds", "Spiunktum", "Elduniory", "Troslunds", "Eldredley", "Eldcolary", "Redelvrld", "Devlosest", "Drafroory", "Golangnet", "Witviltry", "Deawizain", "Warsorach", "Witspidom", "Dralossle", "Witphoake", "Angspitry", "Fropoidom", "Anguniest", "Eldcolire", "Phopoinet", "Frowarnce", "Draredrld", "Kinbrolds", "Golfrodom", "Draqueest", "Drabroain", "Locilland", "Devdraean", "Drakinles", "Loslubies", "Spieviest", "Elvbotnet", "Devsorley", "Devkinchy", "Golillain", "Locsorley", "Deavilrld", "Kinwarest", "Golrotnce", "Drawilnet", "Kineldchy", "Quedeatum", "Prideaake", "Eldbroake", "Locfaiest", "Eldspiley", "Angkinsea", "Froeviory", "Frolocder", "Drauninds", "Frovilach", "Angfroest", "Phoqueoon", "Deawilder", "Locwiznds", "Trorotlds", "Quesorchy", "Warredion", "Golfroout", "Elvtronds", "Elddraies", "Redbotrse", "Kinunkane", "Trounichy", "Spikinsle", "Redlocnse", "Quebotrld", "Frocolean", "Phoslusea", "Deafronds", "Draunkoon", "Deakinion", "Locunkand", "Kinfrochy", "Elvwizest", "Trokinrse", "Prigolane", "Witsluion", "Losfailey", "Phoeviean", "Deakinain", "Locwizest", "Witfroane", "Trogiaand", "Kinspiion", "Devdrands", "Redrotdom", "Spirotnce", "Devwarion", "Phoangtum", "Tropriary", "Kinslules", "Devlorchy", "Frocolnds", "Eldpoisle", "Devpoiory", "Spigiasea", "Redredane", "Quelocnet", "Lockintum", "Golgolles", "Losunisle", "Gollocsea", "Kincolles", "Losprilds", "Spiwilain", "Golrotley", "Frogolion", "Warbotach", "Locunkory", "Draquerth", "Draeldchy", "Wardranet", "Golwizrth", "Devfrorth", "Warkinrth", "Deaangnds", "Elvtroxus", "Lospoiean", "Witunkles", "Spipoiary", "Redwaroon", "Eldevider", "Prifrotry", "Witdraain", "Dradraley", "Trodeaion", "Phospiest", "Trorotley", "Elvlossea", "Loswitach", "Frogollds", "Locfaiion", "Locpoiean", "Frolocand", "Elvelvnse", "Quewilire", "Locbroley", "Wartroles", "Devspilds", "Golkinion", "Redwilley", "Kinkintum", "Fropoiake", "Warrotnds", "Spieldrld", "Phodrachy", "Phodeands", "Losspinds", "Eldlorlds", "Reddrales", "Lossorach", "Warwitnse", "Kinlocion", "Redrotles", "Locrottum", "Angpoiand", "Wargolion", "Elddevand", "Prilocnds", "Lossluory", "Phowitnds", "Redspinet", "Warilldom", "Prielvake", "Troelvrth", "Losunkion", "Froelvand", "Elvcolire", "Unieldion", "Drawitles", "Elvelvnet", "Redbotsea", "Trounkane", "Trodeaire", "Warredest", "Querotean", "Warspiies", "Loswizsea", "Spivilion", "Dealorory", "Quelocand", "Pritrosea", "Angbronds", "Phodevnce", "Prigolain", "Drabroxus", "Warwizire", "Deawitnet", "Spifrorse", "Queuniire", "Priprinse", "Kinphooon", "Frowittum", "Deagialds", "Phoelvnce", "Elvspirth", "Witrotean", "Golelvalm", "Prilocrse", "Trowaries", "Angrotder", "Poiwilion", "Angwaralm", "Deadeaows", "Queredean", "Angbotean", "Frogiaory", "Angsluley", "Drabotoon", "Spilocary", "Wardevach", "Angwizest", "Devwilnds", "Deadraain", "Kinbronds", "Loswittry", "Quepoirse", "Anggiaxus", "Elvlubles", "Warpoiest", "Frogianse", "Trodevalm", "Quekinder", "Queunkane", "Spispisle", "Prikinnds", "Spicolion", "Froredach", "Spisortum", "Goltroles", "Warbrosle", "Phoillows", "Draelvary", "Eldbroies", "Quepoiion", "Frounitum", "Redkinles", "Prifroach", "Devredalm", "Loswilire", "Locwitary", "Wittroles", "Kinloralm", "Deadevain", "Locpoiary", "Frowitane", "Devwarnse", "Redgolach", "Loskinows", "Quephochy", "Elvgoltry", "Trolubder", "Witprinds", "Loskinies", "Devuniean", "Prilubchy", "Elvvilane", "Wartroows", "Witvildom", "Devcolrse", "Queillnet", "Locbroalm", "Witdevest", "Pholocalm", "Trounkrse", "Quecolane", "Witfaitum", "Kintroies", "Losfroary", "Pridraxus", "Reddrarth", "Phovilnce", "Witsluout", "Prirotlds", "Dearotalm", "Wituniain", "Troviltum", "Spisorrld", "Redbroean", "Phobotane", "Spipoinds", "Elvlubrse", "Frowilane", "Pribotean", "Reduniain", "Frobotout", "Frophoalm", "Deaangach", "Deawiztum", "Trogiaory", "Elvangdom", "Deaangire", "Angsluest", "Locelvain", "Kindraire", "Drawarrld", "Kintroion", "Quekinory", "Kinunkach", "Spiwarion", "Eldwizand", "Spislunet", "Goldeales", "Witwarrth", "Spifaitry", "Devprialm", "Losspiake", "Redillean", "Priunkean", "Phospiach", "Elvpoiley", "Elvqueake", "Deveviach", "Phowarake", "Loseldoon", "Warlocles", "Deadrasea", "Phokinrld", "Eldslunds", "Redsorrth", "Redloslds", "Eldbotlds", "Wardrader", "Phosories", "Trogiaion", "Golphoies", "Witrotean", "Trodevtry", "Kineldxus", "Trofroder", "Frogolach", "Lospritry", "Frosluire", "Willorion", "Quepoiand", "Locwilles", "Drabrotry", "Witangder", "Anglosion", "Redkinder", "Golspiles", "Warfaiane", "Witphoach", "Frowilire", "Spirotows", "Pridraire", "Elddeaalm", "Frobotach", "Trounktry", "Drakinire", "Golwiztry", "Redwition", "Kindevion", "Golpriane", "Redelvtum", "Froelvane", "Fropoiout", "Anglosand", "Elvwitand", "Redwilnet", "Drawarles", "Deaunkles", "Deaunknet", "Prirotnse", "Quewilrth", "Wargolout", "Kindeance", "Quewitnce", "Eldunkory", "Warwilder", "Golwition", "Draeldion", "Quesornds", "Eldslusea", "Frowarrse", "Lospoiake", "Angpriake", "Redfroxus", "Deafroion", "Eldbroles", "Devillary", "Pholubout", "Phovilnds", "Golbronet", "Frotroach", "Pholubest", "Golillows", "Devfroalm", "Eldlubach", "Kinreddom", "Pridevnet", "Redredion", "Elvpridom", "Trolosdom", "Elvdeaean", "Locwarire", "Phodeales", "Frokinory", "Witdeaory", "Deaquerld", "Kinsluake", "Spievixus", "Elddeaout", "Quefaialm", "Golspince", "Phobotnet", "Devwizrse", "Phofroain", "Devphonds", "Anguniion", "Locbotnet", "Warunkdom", "Spiwitles", "Warfainds", "Eldelvain", "Prirotnds", "Losbotion", "Frolosire", "Fropoiane", "Redredach", "Angtrorse", "Trobotdom", "Spispichy", "Witspiion", "Warfrosle", "Dealubies", "Frotrotry", "Froevixus", "Froeldsea", "Dealubchy", "Eldpriire", "Eldpoirse", "Golwildom", "Loctronet", "Angeldnce", "Deakinder", "Redvilies", "Elvlubrld", "Golangane", "Querottry", "Prifaitry", "Priwarsle", "Losrotles", "Trodevsea", "Warredand", "Warelvain", "Quedrands", "Locunkalm", "Queunkach", "Warslusea", "Angillles", "Prilubean", "Kinfroain", "Locdralds", "Phoillout", "Kinvillds", "Golkinsea", "Redbotnds", "Witangtry", "Kinwarory", "Anggolnds", "Kinbotley", "Redvilxus"]
		}.ToFrozenDictionary();

		public static CensorConfig Config { get; set; } = new();

		private static Dictionary<CensorType, Dictionary<char, string[]>> SoftCensorCache = new()
		{
				[CensorType.Animal] = [],
				[CensorType.Adjective] = [],
				[CensorType.World] = [],
		};

		private static string[] GetAdjustedCensorList(CensorType ct, string forString)
		{
				if (forString == null || forString.Length == 0 || !Config.LesserCensor)
				{
						return CensorData[ct];
				}
				var c = forString[0];
				if (!SoftCensorCache[ct].TryGetValue(c, out var ret))
				{
						ret = CensorData[ct].Where(x => x.StartsWith(c.ToString(), StringComparison.OrdinalIgnoreCase)).ToArray();
						SoftCensorCache[ct][c] = ret;
				}
				return ret.Length == 0 ? CensorData[ct] : ret;
		}

		public static string Character(string name, string world)
		{
				if (Config.Enabled && !name.IsNullOrEmpty() && !world.IsNullOrEmpty())
				{
						var parts = name.Split(" ");
						var adj = GetAdjustedCensorList(CensorType.Adjective, parts.SafeSelect(0));
						var ani = GetAdjustedCensorList(CensorType.Animal, parts.SafeSelect(1));
						var wor = GetAdjustedCensorList(CensorType.World, world);
						var n1 = Crc32.Get(Config.Seed + name) % adj.Length;
						var n2 = Crc32.Get(Config.Seed + name) % ani.Length;
						var w = Crc32.Get(Config.Seed + world) % wor.Length;
						return $"{adj[n1]} {ani[n2]}@{wor[w]}";
				}
				else
				{
						return $"{name}@{world}";
				}
		}

		public static string Character(string name)
		{
				if (Config.Enabled && !name.IsNullOrEmpty())
				{
						if (name.Contains('@'))
						{
								var x = name.Split("@");
								return Character(x[0], x[1]);
						}
						var parts = name.Split(" ");
						var adj = GetAdjustedCensorList(CensorType.Adjective, parts.SafeSelect(0));
						var ani = GetAdjustedCensorList(CensorType.Animal, parts.SafeSelect(1));
						var n1 = Crc32.Get(Config.Seed + name) % adj.Length;
						var n2 = Crc32.Get(Config.Seed + name) % ani.Length;
						return $"{adj[n1]} {ani[n2]}";
				}
				else
				{
						return name;
				}
		}

		public static string World(string world)
		{
				if (Config.Enabled && !world.IsNullOrEmpty())
				{
						var wor = GetAdjustedCensorList(CensorType.World, world);
						var w = Crc32.Get(Config.Seed + world) % wor.Length;
						return $"{wor[w]}";
				}
				else
				{
						return $"{world}";
				}
		}

		public static string Hide(string s, string placeholder = "Hidden")
		{
				if (Config.Enabled)
				{
						return placeholder;
				}
				else
				{
						return s;
				}
		}

		public static string Hide(object s, string placeholder = "Hidden")
		{
				if (Config.Enabled)
				{
						return placeholder;
				}
				else
				{
						return s.ToString();
				}
		}

		public enum CensorType { Animal, Adjective, World }
}
