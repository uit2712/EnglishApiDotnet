SET IDENTITY_INSERT Groups ON;
INSERT INTO Groups(Id,Name) VALUES (1, N'Động vật');
SET IDENTITY_INSERT Groups OFF;

SET IDENTITY_INSERT Topics ON;
INSERT INTO Topics(Id,Name) VALUES (1, N'Thú cưng'),
(2, N'Các loài chim'),
(3, N'Các động vật biển/dưới nước'),
(4, N'Động vật hoang dã'),
(5, N'Con vật nuôi/trang trại'),
(6, N'Lưỡng cư'),
(7, N'Côn trùng không có cánh'),
(8, N'Côn trùng có cánh');
SET IDENTITY_INSERT Topics OFF;

SET IDENTITY_INSERT Vocabularies ON;
INSERT INTO Vocabularies(Id,Name,Pronunciation,Meaning,Image,TopicId) VALUES (1,N'cat',N'/kæt/',N'mèo',NULL,1),
(2,N'kitten',N'/ˈkɪt.ən/',N'mèo con',NULL,1),
(3,N'dog',N'/dɒg/',N'chó',NULL,1),
(4,N'bitch',N'/bɪtʃ/',N'chó cái',NULL,1),
(5,N'puppy',N'/ˈpʌp.i/',N'chó con',NULL,1),
(6,N'parrot',N'/’pærət/',N'con vẹt',NULL,1),
(7,N'gecko',N'/’gekou/',N'con tắc kè',NULL,1),
(8,N'chinchilla',N'/tʃin’tʃilə/',N'sóc sinsin (ở nam-mỹ)',NULL,1),
(9,N'dalmatian',N'/dælˈmeɪʃən/',N'chó đốm',NULL,1),
(10,N'guinea pig',N'/ˈgɪni pig/',N'chuột lang',NULL,1),
(11,N'hamste',N'/’hæmstə/',N'r  chuột đồng',NULL,1),
(12,N'rabbit',N'/’ræbit/',N'thỏ',NULL,1),
(13,N'bird',N'/bəd/',N': chim',NULL,1),
(14,N'ferret',N'/’ferit/',N'chồn furô',NULL,1),
(15,N'betta fish',N'/ˈbɛtə fiʃ/',N'(fighting fish)  cá chọi',NULL,1),
(16,N'bird',NULL,N'các loài chim nói chung',NULL,2),
(17,N'pheasant',N'/ˈfɛznt/',N'gà lôi',NULL,2),
(18,N'swallow',N'/ˈswɒləʊ/',N'chim én',NULL,2),
(19,N'canary',N'/kəˈneəri/',N'chim hoàng yến',NULL,2),
(20,N'pigeon',N'/ˈpɪʤɪn/',N'chim bồ câu',NULL,2),
(21,N'parrot',N'/ˈpærət/',N'vẹt',NULL,2),
(22,N'crow',N'/krəʊ/',N'quạ',NULL,2),
(23,N'hummingbird',N'/ˈhʌmɪŋbɜːd/',N'chim ruồi',NULL,2),
(24,N'raven',N'/ˈreɪvn/',N'quạ',NULL,2),
(25,N'quail',N'/kweɪl/',N'chim cút',NULL,2),
(26,N'kingfisher',N'/ˈkɪŋˌfɪʃə/',N'chim bói cá',NULL,2),
(27,N'swan',N'/swɒn/',N'thiên nga',NULL,2),
(28,N'woodpecker',N'/ˈwʊdˌpɛkə/',N'chim gõ kiến',NULL,2),
(29,N'toucan',N'/ˈtuːkən/',N'chim toucan',NULL,2),
(30,N'sparrow',N'/ˈspærəʊ/',N'chim sẻ',NULL,2),
(31,N'peacock',N'/ˈpiːkɒk/',N'công',NULL,2),
(32,N'pengui',N'/ˈpɛŋgwɪn/',N'n  chim cánh cụt',NULL,2),
(33,N'ostrich',N'/ˈɒstrɪʧ/',N'đà điểu',NULL,2),
(34,N'seagull',N'/ˈsiːgʌl/',N'chim mòng biển',NULL,2),
(35,N'eagle',N'/ˈiːgl/',N'đại bàng',NULL,2),
(36,N'flamingo',N'/fləˈmɪŋgəʊ/',N'hồng hạc',NULL,2),
(37,N'hawk',N'/hɔːk/',N'diều hâu',NULL,2),
(38,N'stork',N'/stɔːk/',N'cò',NULL,2),
(39,N'falcon',N'/ˈfɔːlkən/',N'chim ưng',NULL,2),
(40,N'vulture',N'/ˈvʌlʧə/',N'kền kền',NULL,2),
(41,N'hawk',N'/hɔk/',N'diều hâu, chim ưng',NULL,2),
(42,N'hen',N'/hen/',N'gà mái',NULL,2),
(43,N'hummingbird',N'/’hʌmiɳ /bəd/',N'chim ruồi',NULL,2),
(44,N'ostrich',N'/’ɔstritʃ/',N'đà điểu châu phi',NULL,2),
(45,N'owl',N'/aul/',N'chim cú',NULL,2),
(46,N'parrot',N'/’pærət/',N'chim vẹt',NULL,2),
(47,N'peacock',N'/’pikɔk/',N'chim công',NULL,2),
(48,N'pelican',N'/’pelikən/',N'chim bồ nông',NULL,2),
(49,N'petrel',N'/’petrəl/',N'hải âu pê-tren (loại nhỏ)',NULL,2),
(50,N'crab',N'/kræb/',N'cua',NULL,3),
(51,N'seal',N'/siːl/',N'hải cẩu',NULL,3),
(52,N'octopus',N'/ˈɒktəpəs/',N'bạch tuộc',NULL,3),
(53,N'shark',N'/ʃɑːk/',N'cá mập',NULL,3),
(54,N'seahorse',N'/ˈsiːhɔːs/',N'cá ngựa',NULL,3),
(55,N'walrus',N'/ˈwɔːlrəs/',N'voi biển',NULL,3),
(56,N'starfish',N'/ˈstɑːfɪʃ/',N'sao biển',NULL,3),
(57,N'whale',N'/weɪl/',N'cá voi',NULL,3),
(58,N'penguin',N'/ˈpɛŋgwɪn/',N'chim cánh cụt',NULL,3),
(59,N'squid',N'/skwɪd/',N'con mực',NULL,3),
(60,N'lobster',N'/ˈlɒbstə/',N'tôm hùm',NULL,3),
(61,N'shrimp',N'/ʃrɪmp/',N'tôm',NULL,3),
(62,N'coral',N'/ˈkɒrəl/',N'san hô',NULL,3),
(63,N'seaweed',N'/ˈsiːwiːd/',N'rong biển',NULL,3),
(64,N'clam',N'/klæmz/',N'con nghêu',NULL,3),
(65,N'sentinel crab',N'/ˈsɛntɪnl kræb/',N'con ghẹ',NULL,3),
(66,N'dolphin',N'/ˈdɒlfɪn/',N'cá heo',NULL,3),
(67,N'mussel',N'/ˈmʌsl/',N'con trai',NULL,3),
(68,N'oyster',N'/ˈɔɪstə/',N'con hàu',NULL,3),
(69,N'scallop',N'/ˈskɒləp/',N'sò điệp',NULL,3),
(70,N'goldfish',N'/ˈgəʊldfɪʃ/',N'cá vàng',NULL,3),
(71,N'salmon',N'/ˈsæmən/',N'cá hồi',NULL,3),
(72,N'sea snail',N'/siː/ /sneɪl/',N'ốc biển',NULL,3),
(73,N'sea urchin',N'/siː/ /ˈɜːʧɪn/',N'nhím biển',NULL,3),
(74,N'sea turtle',N'/siː/ /ˈtɜːtl/',N'rùa biển',NULL,3),
(75,N'sea lion',N'/siː/ /ˈlaɪən/',N'sư tử biển',NULL,3),
(76,N'salamander',N'/ˈsæləˌmændə/',N'kỳ giông',NULL,3),
(77,N'hippopotamus',N'/ˌhɪpəˈpɒtəməs/',N'hà mã',NULL,3),
(78,N'fish',N'/fɪʃ/',N'cá',NULL,3),
(79,N'clownfish',N'/ˈklaʊnfɪʃ/',N'cá hề',NULL,3),
(80,N'common carp',N'/ˈkɒmən kɑːp/',N'cá chép',NULL,3),
(81,N'crocodile',N'/ˈkrɒkədaɪl/',N'cá sấu',NULL,3),
(82,N'anchovy',N'/ˈænʧəvi/',N'cá cơm biển',NULL,3),
(83,N'sperm whale',N'/spɜːm weɪl/',N'cá nhà táng',NULL,3),
(84,N'catfish',N'/ˈkætˌfɪʃ/',N'cá trê',NULL,3),
(85,N'mackerel',N'/ˈmækrəl/',N'cá thu',NULL,3),
(86,N'pomfret',N'/ˈpɒmfrɪt/',N'cá chim',NULL,3),
(87,N'eel',N'/iːl/',N'lươn',NULL,3),
(88,N'flounder',N'/ˈflaʊndə/',N'cá bơn',NULL,3),
(89,N'goby',N'/ˈɡəʊbi/',N'cá bống',NULL,3),
(90,N'herring',N'/ˈhɛrɪŋ/',N'cá trích',NULL,3),
(91,N'catfish',N'/ˈkætfɪʃ/',N'cá trê',NULL,3),
(92,N'tench',N'/tentʃ/',N'cá mè',NULL,3),
(93,N'tilapia',N'/tɪˈlɑːpiə/',N'cá rô',NULL,3),
(94,N'pufferfis',N'/ˈpʌfəfɪʃ/',N'h  cá nóc',NULL,3),
(95,N'suckermouth catfish',N'/ˈsʌkəmaʊθ ˈkatfɪʃ/',N'cá dọn bể',NULL,3),
(96,N'red tilapia',N'/rɛd tɪˈleɪpɪə/',N'cá diêu hồng',NULL,3),
(97,N'swordfish',N'/ˈsɔːdfɪʃ/',N'cá kiếm',NULL,3),
(98,N'stingray',N'/ˈstɪŋreɪ/',N'cá đuối',NULL,3),
(99,N'tuna',N'/ˈtjuːnə/',N'cá ngừ',NULL,3),
(100,N'anabas',N'/ˈanəbəs/',N'cá rô',NULL,3),
(101,N'flowerhorn',N'/ˈflaʊəhɔːn/',N'cá la hán',NULL,3),
(102,N'sardine',N'/sɑːˈdiːn/',N'cá mòi',NULL,3),
(103,N'snakehead fish',N'/ˈsneɪkhɛd fɪʃ/',N'cá quả',NULL,3),
(104,N'angelfish',N'/ˈeɪndʒ(ə)lfɪʃ/',N'cá thiên thần',NULL,3),
(105,N'alligator',N'/ˈælɪgeɪtə/',N'cá sấu mỹ',NULL,3),
(106,N'sea snake',N'/siː sneɪk/',N'rắn biển',NULL,3),
(107,N'frog',N'/frɒg/',N'ếch',NULL,3),
(108,N'jellyfish',N'/ˈdʒel.i.fɪʃ/',N'con sứa',NULL,3),
(109,N'killer whale',N'/ˈkɪl.əʳ weɪl/',N'loại cá voi nhỏ màu đen trắng',NULL,3),
(110,N'seal',N'/siːl/',N'chó biển',NULL,3),
(111,N'squid',N'/skwɪd/',N'mực ống',NULL,3),
(112,N'bear',N'/beə/',N'gấu',NULL,4),
(113,N'polar bear',N'/ˈpəʊlə beə/',N'gấu bắc cực',NULL,4),
(114,N'panda',N'/ˈpændə/',N'gấu trúc',NULL,4),
(115,N'tiger cub',N'/ˈtaɪgə kʌb/',N'hổ con',NULL,4),
(116,N'lion',N'/ˈlaɪən/',N'sư tử',NULL,4),
(117,N'lioness',N'/ˈlaɪənes/',N'sư tử cái',NULL,4),
(118,N'lion cu',N'/ˈlaɪən kʌb/',N'b   sư tử con',NULL,4),
(119,N'tiger',N'/ˈtaɪgə/',N'hổ',NULL,4),
(120,N'tigress',N'/ˈtaɪɡrəs/',N'hổ cái',NULL,4),
(121,N'panther',N'/ˈpænθə/',N'báo đen',NULL,4),
(122,N'leopar',N'/ˈlɛpəd/',N'd  báo đốm',NULL,4),
(123,N'cheeta',N'/ˈʧiːtə/',N'h  báo ghê.ta',NULL,4),
(124,N'gazelle',N'/ɡəˈzel/',N'linh dương',NULL,4),
(125,N'rhinocero',N'/raɪˈnɒsərəs/',N's  tê giác',NULL,4),
(126,N'fox',N'/fɒks/',N'cáo',NULL,4),
(127,N'fawn',N'/fɔːn/',N'nai con',NULL,4),
(128,N'reindeer',N'/ˈreɪndɪə/',N'tuần lộc',NULL,4),
(129,N'elk',N'/ɛlk/',N'nai sừng tấm',NULL,4),
(130,N'moose',N'/muːs/',N'nai sừng tấm',NULL,4),
(131,N'ra',N'/ræt/',N't  chuột',NULL,4),
(132,N'elephant',N'/ˈɛlɪfənt/',N'voi',NULL,4),
(133,N'wolf',N'/wʊlf/',N'sói',NULL,4),
(134,N'deer',N'/dɪə/',N'nai',NULL,4),
(135,N'doe',N'/dəʊ/',N'con nai cái',NULL,4),
(136,N'giraffe',N'/ʤɪˈrɑːf/',N'hươu cao cổ',NULL,4),
(137,N'frog /frɒg/ ếch',N'/frɒg/',N'ếch',NULL,4),
(138,N'snake',N'/sneɪk/',N'rắn',NULL,4),
(139,N'alligator',N'/ˈælɪgeɪtə/',N'cá sấu',NULL,4),
(140,N'crocodile',N'/ˈkrɒkədaɪl/',N'cá sấu',NULL,4),
(141,N'bat',N'/bæt/',N'dơi',NULL,4),
(142,N'gorilla',N'/gəˈrɪlə/',N'gô ri la',NULL,4),
(143,N'giant panda',N'/ˈʤaɪənt ˈpændə/',N'gấu trúc',NULL,4),
(144,N'boar',N'/bɔː/',N'lợn rừng',NULL,4),
(145,N'koala',N'/kəʊˈɑːlə/',N'koala',NULL,4),
(146,N'camel',N'/ˈkæməl/',N'lạc đà',NULL,4),
(147,N'sloth',N'/sləʊθ/',N'con lười',NULL,4),
(148,N'hyena/',NULL,N'haɪˈiːnə linh cẩu',NULL,4),
(149,N'chimpanzee',N'/ˌʧɪmpənˈziː/',N'tinh tinh',NULL,4),
(150,N'zebra',N'/ˈziːbrə/',N'ngựa vằn',NULL,4),
(151,N'squirrel',N'/ˈskwɪrəl/',N'sóc',NULL,4),
(152,N'baboon',N'/bəˈbuːn/',N'khỉ đầu chó',NULL,4),
(153,N'monkey',N'/ˈmʌŋki/',N'khỉ',NULL,4),
(154,N'racoon',N'/rəˈkuːn/',N'gấu mèo',NULL,4),
(155,N'platypus',N'/ˈplætɪpəs/',N'thú mỏ vịt',NULL,4),
(156,N'otter',N'/ˈɒtə/',N'rái cá',NULL,4),
(157,N'skunk',N'/skʌŋk/',N'chồn hôi',NULL,4),
(158,N'chimpanzee',N'/ˌʧɪmpənˈziː/',N'con hắc tinh tinh',NULL,4),
(159,N'badger',N'/ˈbæʤə/',N'con lửng',NULL,4),
(160,N'weasel',N'/ˈwiːzl/',N'chồn',NULL,4),
(161,N'kangaroo',N'/ˌkæŋgəˈru/',N'con chuột túi',NULL,4),
(162,N'hedgehog',N'/ˈhɛʤhɒg/',N'con nhím (ăn thịt)',NULL,4),
(163,N'porcupine',N'/ˈpɔːkjʊpaɪn/',N'con nhím (ăn cỏ)',NULL,4),
(164,N'gazelle',N'/gəˈzel/',N'linh dương gazen',NULL,4),
(165,N'cheetah',N'/ˈtʃiː.tə/',N'báo gêpa',NULL,4),
(166,N'gnu',N'/nuː/',N'linh dương đầu bò',NULL,4),
(167,N'sheep',N'/ʃiːp/',N'cừu',NULL,5),
(168,N'donkey',N'/ˈdɒŋki/',N'lừa',NULL,5),
(169,N'goat',N'/gəʊt/',N'dê',NULL,5),
(170,N'cow',N'/kaʊ/',N'bò',NULL,5),
(171,N'buffalo',N'/ˈbʌfələʊ/',N'trâu',NULL,5),
(172,N'goose /guːs/ ngỗng',N'/guːs/',N'ngỗng',NULL,5),
(173,N'horse',N'/hɔːs/',N'ngựa',NULL,5),
(174,N'dalf',N'/kæf/',N'bê con',NULL,5),
(175,N'duck',N'/dʌk/',N'vịt',NULL,5),
(176,N'drake',N'/dreɪk/',N'vịt đực',NULL,5),
(177,N'duckling',N'/ˈdʌklɪŋ/',N'vịt con',NULL,5),
(178,N'chicken',N'/ˈʧɪkɪn/',N'gà',NULL,5),
(179,N'rooster /ˈruːstə/ gà trống',N'/ˈruːstə/',N'gà trống',NULL,5),
(180,N'hen',N'/hɛn/',N'gà mái',NULL,5),
(181,N'turkey',N'/ˈtɜːki/',N'gà tây',NULL,5),
(182,N'piglet',N'/ˈpɪglət/',N'lợn con',NULL,5),
(183,N'rabbit',N'/ˈræbɪt/',N'thỏ',NULL,5),
(184,N'ox',N'/ɒks/',N'bò',NULL,5),
(185,N'water buffalo',N'/ˈwɔːtə ˈbʌfələʊ/',N'trâu',NULL,5),
(186,N'pig',N'/pɪg/',N'lợn',NULL,5),
(187,N'bunny',N'/ˈbʌni/',N'thỏ con',NULL,5),
(188,N'earthworm',N'/ɜːθ wɜːm/',N'giun đất',NULL,5),
(189,N'cattle',N'/ˈkætl/',N'gia súc',NULL,5),
(190,N'dog',NULL,N'dɔːɡ chó đực',NULL,5),
(191,N'puppy',N'/ˈpʌpi/',N'chó con',NULL,5),
(192,N'queen',N'/kwiːn/',N'mèo cái',NULL,5),
(193,N'kitten',N'/ˈkɪtn/',N'mèo con',NULL,5),
(194,N'cat',N'/kæt/',N'mèo',NULL,5),
(195,N'sheep',N'/ʃiːp/',N'con cừu',NULL,5),
(196,N'dairy cow',N'/ˈdeə.ri kaʊ/',N'con bò sữa',NULL,5),
(197,N'horses',N'/hɔːsiz/',N'con ngựa',NULL,5),
(198,N'paѕture',N'/ˈpɑːѕ.tʃəʳ/',N'bãi ᴄhăn thả ᴠật nuôi',NULL,5),
(199,N'farmer',N'/ˈfɑː.məʳ/',N'người nông dân, ᴄhủ trang trại',NULL,5),
(200,N'barnуard',N'/ˈbɑːn.jɑːd/',N'ѕân nuôi gia ѕúc',NULL,5),
(201,N'cattle',N'/ˈkæt.ļ/',N'(một đàn) gia ѕúᴄ',NULL,5),
(202,N'coᴡboу',N'/ˈkaʊ.bɔɪ/',N'ᴄậu bé ᴄhăn bò',NULL,5),
(203,N'coᴡgirl',N'/ˈkaʊ.gɜːl/',N'ᴄô gái ᴄhăn bò',NULL,5),
(204,N'alligato',N'/ˈæl.ɪ.geɪ.təʳ/',N'r  cá sấu mỹ',NULL,6),
(205,N'crocodile',N'/ˈkrɒk.ə.daɪl/',N'cá sấu',NULL,6),
(206,N'toad',N'/təʊd/',N'con cóc',NULL,6),
(207,N'frog',N'/frɒg/',N'con ếch',NULL,6),
(208,N'dinosaurs',N'/’daɪnəʊsɔː/',N'khủng long',NULL,6),
(209,N'cobra - fang',N'/ˈkəʊ.brə. fæŋ/',N'rắn hổ mang-răng nanh',NULL,6),
(210,N'chameleon',N'/kəˈmiː.li.ən/',N'tắc kè hoa',NULL,6),
(211,N'dragon',N'/ˈdræg.ən/',N'con rồng',NULL,6),
(212,N'turtle-shell',N'/ˈtɜː.tl ʃel/',N'mai rùa',NULL,6),
(213,N'lizard/',NULL,N'ˈlɪz.əd thằn lằn',NULL,6),
(214,N'ant',N'/ænt/',N'- con kiến',NULL,7),
(215,N'fire ant',N'/faɪə ænt/',N'- kiến lửa',NULL,7),
(216,N'rove beetle',N'/rəʊv biːtl/',N'- kiến ba khoang',NULL,7),
(217,N'millipede',N'/ˈmɪləpiːd/',N'- con cuốn chiếu',NULL,7),
(218,N'spider',N'/ˈspaɪ.dəʳ/',N'- nhện',NULL,7),
(219,N'cocoon',N'/kəˈkuːn/',N'- kén',NULL,7),
(220,N'aphid',N'/ˈeɪfɪd/',N'- con rệp cây',NULL,7),
(221,N'centipede',N'/ˈsen.tɪ.piːd/',N'- con rết',NULL,7),
(222,N'scorpion',N'/ˈskɔː.pi.ən/',N'- bọ cạp',NULL,7),
(223,N'flea  /fliː/- con bọ chét',NULL,NULL,NULL,7),
(224,N'slug',N'/slʌɡ/',N'- sên nhớt',NULL,7),
(225,N'earthworm',N'/ˈɜːθ wɜːm/',N'- giun đất',NULL,7),
(226,N'maggot',N'/ˈmæɡət/',N'- con giòi',NULL,7),
(227,N'snail',N'/sneɪl/',N'- ốc sên',NULL,7),
(228,N'tapeworm',N'/ˈteɪp wɜːm/',N'- sán dây',NULL,7),
(229,N'hookworm',N'/hʊk wɜːm/',N'- giun móc',NULL,7),
(230,N'large roundworm',N'/lɑːdʒ raʊnd wɜːm/',N'- giun đũa',NULL,7),
(231,N'tick',N'/tɪk/',N'- con bọ ve',NULL,7),
(232,N'louse',N'/laʊs/',N'- con rận',NULL,7),
(233,N'caterpillar',N'/ˈkæt.ə.pɪl.əʳ/',N'- sâu bướm',NULL,8),
(234,N'giant water bug',N'/ˈdʒaɪənt ˈwɔːtə bʌɡ/',N'- cà cuống',NULL,8),
(235,N'stink bug',N'/stɪŋk bʌɡ/',N'- bọ xít',NULL,8),
(236,N'cicada',N'/səˈkɑːdə/',N'- ve sầu',NULL,8),
(237,N'butterfly',N'/ˈbʌt.ə.flaɪ/',N'- bướm',NULL,8),
(238,N'moth',N'/mɒθ/',N'- bướm đêm, sâu bướm',NULL,8),
(239,N'cockroach',N'/ˈkɒk.rəʊtʃ/',N'- con gián',NULL,8),
(240,N'cricket',N'/ˈkrɪk.ɪt/',N'- con dế',NULL,8),
(241,N'dragonfly',N'/ˈdrægən flaɪ/',N'- chuồn chuồn',NULL,8),
(242,N'damselfly',N'/ˈdæmzəl flaɪ/',N'- chuồn chuồn kim',NULL,8),
(243,N'bee',N'/biː/',N'- con ong',NULL,8),
(244,N'wasp',N'/wɒsp/',N'- ong bắp cày',NULL,8),
(245,N'firefly',N'/ˈfaɪə flaɪ/',N'- đom đóm',NULL,8),
(246,N'fly',N'/flaɪz/',N'- con ruồi',NULL,8),
(247,N'grasshopper',N'/ˈgrɑːsˌhɒp.əʳ/',N'- châu chấu',NULL,8),
(248,N'termite',N'/ˈtɜː.maɪt/',N'- con mối',NULL,8),
(249,N'mosquito',N'/məˈskiː.təʊ/',N'- con muỗi',NULL,8),
(250,N'ladybug',N'/ˈleɪ.di.bɜːd/',N'- con bọ rùa',NULL,8),
(251,N'scarab beetle',N'/ˈskærəb ˈbiː.tļ/',N'- bọ hung',NULL,8),
(252,N'mantis',N'/ˈmæn.tɪs/',N'- con bọ ngựa',NULL,8),
(253,N'beetle',N'/ˈbiː.tļ/',N'- bọ cánh cứng',NULL,8),
SET IDENTITY_INSERT Vocabularies OFF;