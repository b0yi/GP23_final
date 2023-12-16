using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSubtitle : Subtitle
{
    public List<string> firstTalk = new List<string>() {
        "C-111：「我的天啊，一個活跳跳的金星人！」",
        "C-111：「Messenger-107，這真是......令本喵驚訝。」",
        "M-107(玩家)：「我該如何返回我的家園...」",
        "C-111：「你是認真的嗎？」",
        "C-111：「回家可不是一件容易的事。」",
        "M-107(玩家)：「你以為我很喜歡在這待著？」",
        "C-111：「......呃，本喵是不討厭啦。」",
        "C-111：「不管怎麼說，本喵幫不了你。」",
        "C-111：「但這附近有顆神秘的海洋星。」",
        "C-111：「在離太陽這麼遠的地方，居然有液態水。熱源究竟是什麼呢？」",
        "C-111：「或許你可以到哪邊看看。」"
    };

    public List<List<string>> keepTalk = new List<List<string>>() {
        new List<string>() {
            "C-111：「如你所見，這裡全是沙。」",
            "C-111：「除了會說話跟可愛程度以外，本喵跟普通的貓沒什麼差別。」"
        },
        new List<string>() {
            "C-111：「本喵曾經假裝成寵物貓，在地球潛竊取機密情報。」", 
            "C-111：「危險？地球人根本沒懷疑過。誰會懷疑像本喵這樣超級無敵可愛的小貓咪？」"
        },
        new List<string>() {
            "C-111：「本喵是C-111。」", 
            "C-111：「C不是載體(Carrier)，而是貓(Cat)！」", 
            "C-111：「本喵堅持！」"
        },
        new List<string>() {
            "C-111：「快搔搔本喵的下巴。快！」"
        },
        new List<string>() {
            "C-111：「本喵的確需要一些源流體。」",
            "C-111：「那是一種本能。」",
            "C-111：「紙箱跟源流體，同樣的難以抗拒。」"
        },
        new List<string>() {
            "C-111：「這附近有一顆神秘的海洋星。」",
            "C-111：「在離太陽這麼遠的地方，居然有液態水。熱源究竟是什麼呢？」",
            "C-111：「但本喵不喜歡弄濕鬍鬚。」"
        },
        new List<string>() {
            "C-111：「那個醜陋的黑洞，黑的毫無品味。跟本喵的毛色相比可差遠了。」",
            "C-111：「不許說看不出區別。」"
        },
        new List<string>() {
            "C-111：「星體在自己的重力下坍塌，最終形成廣義相對論預測的類星體。緻密的質量足以扭曲時空，在外圍形成不可逃脫的事件視界。由於逃逸速度超越光速，沒有任何物質能夠離開。」",
            "C-111：「你真的想聽這些？」"
        }
    };

    public List<List<string>> waterTalk = new List<List<string>>() {
        new List<string>() {
            "C-111：「嘖。」",
            "C-111：「不，你聽錯了。」",
            "C-111：「有總比沒有好。」",
            "C-111：「......或許這麼做能幫到你。」"
        },
        new List<string>() {
            "C-111：「金星戰爭改變了很多事情。」",
            "C-111：「比如說，貓草變成固定配給。」"
        }
    };

    public List<List<string>> fishTalk = new List<List<string>>() {
        new List<string>() {
            "C-111：「聽說海洋星裡住著一種危險的生物。不少探險隊折在牠手裡。」",
            "C-111：「人們稱呼那個怪物為『海洋老人』。」",
            "C-111：「什麼？你遇到牠了？」",
            "C-111：「......你怎麼還活著？」"
        },
        new List<string>() {
            "C-111：「你聽過創造引力的武器嗎？」",
            "C-111：「地球人用那種東西，將我們的同盟星化成一顆顆黑洞。人們還來不及呼救，就被自己呼吸的空氣壓碎。」",
            "C-111：「老話說得好：地球人，狗都不如。」"
        }
    };
    

    // Start is called before the first frame update
    void Start()
    {
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
