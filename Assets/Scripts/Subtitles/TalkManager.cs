using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SubtitleStage {
    stele = 0,
    cat,
    fish,
    outsideMaze,
    enterMaze,
    portal,
    portalFixed,
    dragonPlanet,
    crystal,
}

public enum DeadString {
    fuel = 0,
    blackhold,
    sun,
    fish,
    rock,
    dragon,
}

public class TalkManager : MonoBehaviour
{
    public SubtitleStage nextSubtitle = SubtitleStage.stele;
    public float charPerSec = 20f;
    public float delayTime = 1.3f;

    [DisplayOnly] public List<bool> treeBools = new List<bool>() {
        false, // tree near born
        false, // tree near cat
        false, // tree near fish
        false  // tree near maze
    };
    public bool bornBool = false;
    public bool brokenPlanetBool = false;
    public bool sunBool = false;
    public bool dragonBuildingBool = false;
    public bool dragonCrystalBool = false;

    public List<List<string>> subtitles = new List<List<string>>() {
        // stele - 0
        new List<string>() {
            "<color=#E7A472>你想起來這個裝置的用途。</color>",
            "<color=#E7A472>雖然大部分的功能已經失去，裝置仍告訴你，這片星空還有一位你的族人。</color>",
            "<color=#E7A472>一個......金星人。</color>",
        },
        // cat - 1
        new List<string>() {
            "貓-111: 我的老天啊！",
            "貓-111: 這真是令人吃驚。孩子，告訴我，你從何而來？",
            "<color=#B1FDFF>雖然型態與你不同，但這確實是一位金星人。</color>",
            "<color=#B1FDFF>你告訴了他，自己甦醒了過來。</color>",
            "貓-111: 一個倖存者......難以置信。",
            "貓-111: 大戰結束後，我就再也沒有遇過一個金星人。",
            "<color=#B1FDFF>你心想，這怎麼可能呢？</color>",
            "貓-111: 有沒有感受到那異常的重力？",
            "貓-111: 黑洞阻止了所有物質離開。我們只能在這裡，等待能量耗盡。",
            "<color=#B1FDFF>黑洞。</color>",
            // 鏡頭轉移
            "<color=#B1FDFF>事件視界阻斷了一切。</color>",
            "<color=#B1FDFF>你很平靜。經過那麼久，能甦醒已是奇蹟。</color>",
            "<color=#B1FDFF>你唯一好奇的是，金星......你的家，是否熬過了那場戰爭。</color>",
            "貓-111: 我很遺憾，孩子。",
            "貓-111: 這幾十年我沒有收到任何金星的消息。",
            "貓-111: 恐怕......",
            "<color=#B1FDFF>這並不令人驚訝。</color>",
            "<color=#B1FDFF>但你仍然感到哀傷。</color>",
            "<color=#B1FDFF>......你想，回家。</color>",
            "貓-111: 即使你將見證的景象令人痛心？",
            "貓-111: 我恐怕無法幫助你。",
            "貓-111: 但如果想要擺脫黑洞的重力，你可以去海洋星看看。",
            // 鏡頭轉移
            "貓-111: 離太陽如此遙遠的軌道居然有液態水，本身就是奇蹟。",
            "貓-111: 一定有非常強大的源流場改變了星球的生態。",
        },
        // fish - 2
        new List<string>() {
            "貓魚: 來自深淵的凝視。",
            "<color=#B1FDFF>你感受到自己的意識被輕易的入侵。</color>",
            "<color=#B1FDFF>這感覺很不舒服。</color>",
            "貓魚: 人類......",
            "貓魚: 你們來來去去，只會帶來災厄。你為何而來？",
            "<color=#B1FDFF>你告訴它，自己想要回家。</color>",
            "<color=#B1FDFF>深淵之主不屑的睥睨。</color>",
            "貓魚: 你們的造物可以「創造」黑洞，自然也能消滅黑洞。",
            "貓魚: 人類，你找錯地方了。",
            "<color=#B1FDFF>你有些不明白。</color>",
            "貓魚: 一個遠比我強大的存在，潛伏在空間的夾縫中。",
            "貓魚: ......在那個迷宮之中。",
        },
        // outsideMaze - 3
        new List<string>() {
            "<color=#B1FDFF>迷宮星？</color>",
            "這個星球上什麼都沒有啊",
        },
        // enterMaze - 4
        new List<string>() {
            "<color=#B1FDFF>這難道就是…..迷宮！？！</color>",
        },
        // portal - 5
        new List<string>() {
            "<color=#B1FDFF>傳送門？是誰搭建的？</color>",
            "<color=#B1FDFF>無法成功啟動，似乎是故障了。</color>",
            "<color=#B1FDFF>好奇心的驅使下，你決定嘗試修復它。</color>",
            "<color=#B1FDFF>四周也許有一些 <b><i>資源</i></b>可以採集。</color>",
        },
        // portalFixed - 6
        new List<string>() {
            "<color=#B1FDFF>傳送門成功修復好了。</color>",
        },
        // dragonPlanet - 6
        new List<string>() {
            "<color=#FFCCE4>這不是你孰悉的傳送技術。你很不可置信。</color>",
            "<color=#FFCCE4>你感覺到星球底下有股巨大的力量在隱隱攢動。</color>",
            "<color=#FFCCE4>更令你驚訝的是，這裡......封印著一個偉大的存在。</color>",
            "<color=#FFCCE4>在太陽的引力內，無人不知它的名諱。它代表著金星的黃金歲月，那一去不復返的強盛帝國。</color>",
        },
        // crystal - 7
        new List<string>() {
            "<color=#FFCCE4>你不知道這頭巨獸是否會聽從你的話語。</color>",
            "<color=#FFCCE4>但你仍有信心。</color>",
            "<color=#FFCCE4>因為它曾是金星人的驕傲與榮光。</color>",
            "<color=#FFCCE4>而現在，一個金星人正在呼喚它。</color>",
            "<color=#FFCCE4>你說：</color>",
            "M-107: 醒來，老兵。",
            "M-107: 求求你，讓我回家。",
        },
    };

    public List<List<string>> treeSubtitles = new List<List<string>>() {
        // tree near born
        new List<string>() {
            "<color=#E7A472>這些裝置正在吸取源流體，從這顆名叫O的星球上。</color>",
        },
        // tree near cat
        new List<string>() {
            "<color=#E7A472>金星人派遣信使前往各個星球，只爲了獲取更多源流體。</color>",
        },
        // tree near water
        new List<string>() {
            "<color=#E7A472>這顆星球......正在老去。</color>",
        },
        // tree near maze
        new List<string>() {
            "<color=#E7A472>源流體所剩無幾，但還勉強能讓你航行。</color>",
        },
        // tree in maze
        // new List<string>() {
        //     "<color=#B1FDFF>There were your fellow beings here.</color>",
        // },
    };

    public List<string> bornSubtitle = new List<string>() {
        "你什麼都想不起來，只記得突如其來的震盪使自己陷入昏迷。",
    };

    public List<string> brokenBuildingSubtitle = new List<string>() {
        "<color=#B1FDFF>這不是這個星球原本的模樣。不知為何，你很肯定。</color>",
    };

    public List<string> brokenPlanetSubtitle = new List<string>() {
        "<color=#B1FDFF>這顆星球被耗盡了源流體，徹底的崩坍了。</color>",
        "<color=#B1FDFF>不用多久，這附近所有的星球都會面臨相同的下場。</color>",
    };

    public List<string> sunSubtitle = new List<string>() {
        "一顆燃燒的星球。",
        "希望金星最終不會變成這副模樣。",
    };

    public List<string> deadSubtitle = new List<string>() {
        "沒有了源流體，該怎麼回家......",
        "黑洞吞沒了一切，也吞沒了你......無一倖免",
        "太陽的高溫......金星......不......",
        "「鯨」為天人！鯨魚把金星人吃個精光！",
        "以卵擊石......在它面前，你僅僅是個卵......",
        "耶夢加德......不應該是這樣的......",
    };

    public List<string> dragonBuildingSubtitle = new List<string>() {
        "<color=#FFCCE4>人類跟本不遵守宇宙生態法則，他們四處掠奪肆掠，甚至還創造出了可以造成行星坍縮的武器。</color>",
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
