using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatConversation : MonoBehaviour
{
    private List<string> firstTalk = new List<string>() {
        "「...」",
        "「我的天啊，一個活跳跳的金星人！」",
        "「Messenger-107，這真是......令本喵驚訝。」"
    };

    private List<string> secondTalk = new List<string>() {
        "「你是認真的嗎？」",
        "「回家可不是一件容易的事。」",
        "「你以為本喵很喜歡在這待著？」",
        "「......呃，本喵是不討厭啦。」",
        "「不管怎麼說，本喵幫不了你。如你所見，這裡全是沙。」",
        "「除了會說話跟可愛程度以外，本喵跟普通的貓沒什麼差別。」"
    };

    private List<List<string>> keepTalk = new List<List<string>>() {
        new List<string>() {
            "「本喵曾經假裝成寵物貓，在地球潛竊取機密情報。」", 
            "「危險？地球人根本沒懷疑過。誰會懷疑像本喵這樣超級無敵可愛的小貓咪？」"
        },
        new List<string>() {
            "「本喵是C-111。」", 
            "「C不是載體(Carrier)，而是貓(Cat)！」", 
            "「本喵堅持！」"
        },
        new List<string>() {
            "「快搔搔本喵的下巴。快！」"
        },
        new List<string>() {
            "「本喵的確需要一些源流體。」",
            "「那是一種本能。」",
            "「紙箱跟源流體，同樣的難以抗拒。」"
        },
        new List<string>() {
            "「這附近有一顆神秘的海洋星。」",
            "「在離太陽這麼遠的地方，居然有液態水。據說源流體在極低的濃度下，會以熱能發散......」",
            "「但本喵不喜歡弄濕鬍鬚。」"
        },
        new List<string>() {
            "「那個巨大的黑傢伙，黑的毫無品味。跟本喵的毛色相比可差遠了。」",
            "「不許說看不出區別。」"
        },
        new List<string>() {
            @"「星體在自己的重力下坍塌，最終形成廣義相對論預測的類星體。
            緻密的質量足以扭曲時空，在外圍形成不可逃脫的事件視界。
            由於逃逸速度超越光速，沒有任何物質能夠離開。」",
            "「你真的想聽這些？」"
        }
    };

    private List<List<string>> waterTalk = new List<List<string>>() {
        new List<string>() {
            "「嘖。」",
            "「不，你聽錯了。」",
            "「有總比沒有好。」",
            "「......或許這麼做能幫到你。」"
        },
        new List<string>() {
            "「金星戰爭改變了很多事情。」",
            "「比如說，貓草變成固定配給。」"
        }
    };

    private List<string> fishTalk = new List<string>() {
        "「聽說海洋星裡住著一種危險的生物。不少探險隊折在牠手裡。」",
        "「人們稱呼那個怪物為『海洋老人』。」",
        "「什麼？你遇到牠了？」",
        "「......你怎麼還活著？」"
    };
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
