// <copyright file="HIDKeyboardScanCode.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System.ComponentModel;

namespace Macro9Pad.Helpers
{
  /// <summary>
  /// Enum for keyboard scancodes.
  /// </summary>
  public enum HIDKeyboardScanCode
  {
    /// <summary>No key pressed.</summary>
    [Description("None")]
    None = 0x00,

    /// <summary>Keyboard Error Roll Over ("Phantom Key").</summary>
    [Description("Error Rollover")]
    ErrorRollover = 0x01,

    /// <summary>Keyboard POST Fail.</summary>
    [Description("Error Post Fail")]
    ErrorPostFail = 0x02,

    /// <summary>Keyboard Error Undefined.</summary>
    [Description("Error Undefined")]
    ErrorUndefined = 0x03,

    /// <summary>Keyboard a and A.</summary>
    [Description("a")]
    KeyA = 0x04,

    /// <summary>Keyboard b and B.</summary>
    [Description("b")]
    KeyB = 0x05,

    /// <summary>Keyboard c and C.</summary>
    [Description("c")]
    KeyC = 0x06,

    /// <summary>Keyboard d and D.</summary>
    [Description("d")]
    KeyD = 0x07,

    /// <summary>Keyboard e and E.</summary>
    [Description("e")]
    KeyE = 0x08,

    /// <summary>Keyboard f and F.</summary>
    [Description("f")]
    KeyF = 0x09,

    /// <summary>Keyboard g and G.</summary>
    [Description("g")]
    KeyG = 0x0a,

    /// <summary>Keyboard h and H.</summary>
    [Description("h")]
    KeyH = 0x0b,

    /// <summary>Keyboard i and I.</summary>
    [Description("i")]
    KeyI = 0x0c,

    /// <summary>Keyboard j and J.</summary>
    [Description("j")]
    KeyJ = 0x0d,

    /// <summary>Keyboard k and K.</summary>
    [Description("k")]
    KeyK = 0x0e,

    /// <summary>Keyboard l and L.</summary>
    [Description("l")]
    KeyL = 0x0f,

    /// <summary>Keyboard m and M.</summary>
    [Description("m")]
    KeyM = 0x10,

    /// <summary>Keyboard n and N.</summary>
    [Description("n")]
    KeyN = 0x11,

    /// <summary>Keyboard o and O.</summary>
    [Description("o")]
    KeyO = 0x12,

    /// <summary>Keyboard p and P.</summary>
    [Description("p")]
    KeyP = 0x13,

    /// <summary>Keyboard q and Q.</summary>
    [Description("q")]
    KeyQ = 0x14,

    /// <summary>Keyboard r and R.</summary>
    [Description("r")]
    KeyR = 0x15,

    /// <summary>Keyboard s and S.</summary>
    [Description("s")]
    KeyS = 0x16,

    /// <summary>Keyboard t and T.</summary>
    [Description("t")]
    KeyT = 0x17,

    /// <summary>Keyboard u and U.</summary>
    [Description("u")]
    KeyU = 0x18,

    /// <summary>Keyboard v and V.</summary>
    [Description("v")]
    KeyV = 0x19,

    /// <summary>Keyboard w and W.</summary>
    [Description("w")]
    KeyW = 0x1a,

    /// <summary>Keyboard x and X.</summary>
    [Description("x")]
    KeyX = 0x1b,

    /// <summary>Keyboard y and Y.</summary>
    [Description("y")]
    KeyY = 0x1c,

    /// <summary>Keyboard z and Z.</summary>
    [Description("z")]
    KeyZ = 0x1d,

    /// <summary>Keyboard 1 and !.</summary>
    [Description("1!")]
    Key1 = 0x1e,

    /// <summary>Keyboard 2 and @.</summary>
    [Description("2@")]
    Key2 = 0x1f,

    /// <summary>Keyboard 3 and #.</summary>
    [Description("3#")]
    Key3 = 0x20,

    /// <summary>Keyboard 4 and $.</summary>
    [Description("4$")]
    Key4 = 0x21,

    /// <summary>Keyboard 5 and %.</summary>
    [Description("5%")]
    Key5 = 0x22,

    /// <summary>Keyboard 6 and ^.</summary>
    [Description("6^")]
    Key6 = 0x23,

    /// <summary>Keyboard 7 and &amp;.</summary>
    [Description("7&")]
    Key7 = 0x24,

    /// <summary>Keyboard 8 and *.</summary>
    [Description("8*")]
    Key8 = 0x25,

    /// <summary>Keyboard 9 and (.</summary>
    [Description("9(")]
    Key9 = 0x26,

    /// <summary>Keyboard 0 and ).</summary>
    [Description("0)")]
    Key0 = 0x27,

    /// <summary>Keyboard Return (ENTER).</summary>
    [Description("Enter")]
    KeyEnter = 0x28,

    /// <summary>Keyboard ESCAPE.</summary>
    [Description("Escape")]
    KeyESC = 0x29,

    /// <summary>Keyboard DELETE (Backspace).</summary>
    [Description("Backspace")]
    KeyBackspace = 0x2a,

    /// <summary>Keyboard Tab.</summary>
    [Description("Tab")]
    KeyTab = 0x2b,

    /// <summary>Keyboard Spacebar.</summary>
    [Description("")]
    KeySpace = 0x2c,

    /// <summary>Keyboard - and _.</summary>
    [Description("-_")]
    KeyMinus = 0x2d,

    /// <summary>Keyboard = and +.</summary>
    [Description("=+")]
    KeyEqual = 0x2e,

    /// <summary>Keyboard [ and {.</summary>
    [Description("[{")]
    KeyLeftBrace = 0x2f,

    /// <summary>Keyboard ] and }.</summary>
    [Description("]}")]
    KeyRightBrace = 0x30,

    /// <summary>Keyboard \ and |.</summary>
    [Description(@"\|")]
    KeyBackSlash = 0x31,

    /// <summary>Keyboard Non-US # and ~.</summary>
    [Description("Non-US #~")]
    KeyHashTilde = 0x32,

    /// <summary>Keyboard ; and :.</summary>
    [Description(";:")]
    KeySemicolon = 0x33,

    /// <summary>Keyboard ' and ".</summary>
    [Description("'\"")]
    KeyApostrophe = 0x34,

    /// <summary>Keyboard ` and ~.</summary>
    [Description("`~")]
    KeyGrave = 0x35,

    /// <summary>Keyboard , and LESSTHAN &lt;.</summary>
    [Description(",<")]
    KeyComma = 0x36,

    /// <summary>Keyboard . and >.</summary>
    [Description(".>")]
    KeyPeriod = 0x37,

    /// <summary>Keyboard / and ?.</summary>
    [Description("/?")]
    KeyForwardSlash = 0x38,

    /// <summary>Keyboard Caps Lock.</summary>
    [Description("Caps Lock")]
    KeyCapslock = 0x39,

    /// <summary>Keyboard F1.</summary>
    [Description("F1")]
    KeyF1 = 0x3a,

    /// <summary>Keyboard F2.</summary>
    [Description("F2")]
    KeyF2 = 0x3b,

    /// <summary>Keyboard F3.</summary>
    [Description("F3")]
    KeyF3 = 0x3c,

    /// <summary>Keyboard F4.</summary>
    [Description("F4")]
    KeyF4 = 0x3d,

    /// <summary>Keyboard F5.</summary>
    [Description("F5")]
    KeyF5 = 0x3e,

    /// <summary>Keyboard F6.</summary>
    [Description("F6")]
    KeyF6 = 0x3f,

    /// <summary>Keyboard F7.</summary>
    [Description("F7")]
    KeyF7 = 0x40,

    /// <summary>Keyboard F8.</summary>
    [Description("F8")]
    KeyF8 = 0x41,

    /// <summary>Keyboard F9.</summary>
    [Description("F9")]
    KeyF9 = 0x42,

    /// <summary>Keyboard F10.</summary>
    [Description("F10")]
    KeyF10 = 0x43,

    /// <summary>Keyboard F11.</summary>
    [Description("F11")]
    KeyF11 = 0x44,

    /// <summary>Keyboard F12.</summary>
    [Description("F12")]
    KeyF12 = 0x45,

    /// <summary>Keyboard Print Screen.</summary>
    [Description("Print Screen")]
    KeyPrintScreen = 0x46,

    /// <summary>Keyboard Scroll Lock.</summary>
    [Description("Scroll Lock")]
    KeyScrollLock = 0x47,

    /// <summary>Keyboard Pause.</summary>
    [Description("Pause/Break")]
    KeyPause = 0x48,

    /// <summary>Keyboard Insert.</summary>
    [Description("Insert")]
    KeyInsert = 0x49,

    /// <summary>Keyboard Home.</summary>
    [Description("Home")]
    KeyHome = 0x4a,

    /// <summary>Keyboard Page Up.</summary>
    [Description("Page Up")]
    KeyPageUp = 0x4b,

    /// <summary>Keyboard Delete Forward.</summary>
    [Description("Delete")]
    KeyDelete = 0x4c,

    /// <summary>Keyboard End.</summary>
    [Description("End")]
    KeyEnd = 0x4d,

    /// <summary>Keyboard Page Down.</summary>
    [Description("Page Down")]
    KeyPageDown = 0x4e,

    /// <summary>Keyboard Right Arrow.</summary>
    [Description("RightArrow")]
    KeyRight = 0x4f,

    /// <summary>Keyboard Left Arrow.</summary>
    [Description("LeftArrow")]
    KeyLeft = 0x50,

    /// <summary>Keyboard Down Arrow.</summary>
    [Description("DownArrow")]
    KeyDown = 0x51,

    /// <summary>Keyboard Up Arrow.</summary>
    [Description("UpArrow")]
    KeyUp = 0x52,

    /// <summary>Keyboard Num Lock and Clear.</summary>
    [Description("Numlock/Clear")]
    KeyNPNumlock = 0x53,

    /// <summary>Keypad /.</summary>
    [Description(@"Keypad /")]
    KeyNPSlash = 0x54,

    /// <summary>Keypad *.</summary>
    [Description("Keypad *")]
    KeyNPAsterisk = 0x55,

    /// <summary>Keypad -.</summary>
    [Description("Keypad -")]
    KeyNPMinus = 0x56,

    /// <summary>Keypad +.</summary>
    [Description("Keypad +")]
    KeyNPPlus = 0x57,

    /// <summary>Keypad ENTER.</summary>
    [Description("Keypad Enter")]
    KeyNPEnter = 0x58,

    /// <summary>Keypad 1 and End.</summary>
    [Description("Keypad 1/End")]
    KeyNP1 = 0x59,

    /// <summary>Keypad 2 and Down Arrow.</summary>
    [Description("Keypad 2/DownArrow")]
    KeyNP2 = 0x5a,

    /// <summary>Keypad 3 and PageDn.</summary>
    [Description("Keypad 3/PageDown")]
    KeyNP3 = 0x5b,

    /// <summary>Keypad 4 and Left Arrow.</summary>
    [Description("Keypad 4/LeftArrow")]
    KeyNP4 = 0x5c,

    /// <summary>Keypad 5.</summary>
    [Description("Keypad 5")]
    KeyNP5 = 0x5d,

    /// <summary>Keypad 6 and Right Arrow.</summary>
    [Description("Keypad 6/RightArrow")]
    KeyNP6 = 0x5e,

    /// <summary>Keypad 7 and Home.</summary>
    [Description("Keypad 7/Home")]
    KeyNP7 = 0x5f,

    /// <summary>Keypad 8 and Up Arrow.</summary>
    [Description("Keypad 8/UpArrow")]
    KeyNP8 = 0x60,

    /// <summary>Keypad 9 and Page Up.</summary>
    [Description("Keypad 9/PageUp")]
    KeyNP9 = 0x61,

    /// <summary>Keypad 0 and Insert.</summary>
    [Description("Keypad 0/Insert")]
    KeyNP0 = 0x62,

    /// <summary>Keypad . and Delete.</summary>
    [Description("Keypad ./Delete")]
    KeyNPDOT = 0x63,

    /// <summary>Keyboard Non-US \ and |.</summary>
    [Description(@"Non-US \|")]
    Key102ND = 0x64,

    /// <summary>Keyboard Application.</summary>
    [Description("Application")]
    KeyCompose = 0x65,

    /// <summary>Keyboard Power.</summary>
    [Description("Power")]
    KeyPower = 0x66,

    /// <summary>Keypad =.</summary>
    [Description("Keypad =.")]
    KeyNPEqual = 0x67,

    /// <summary>Keyboard F13.</summary>
    [Description("F13")]
    KeyF13 = 0x68,

    /// <summary>Keyboard F14.</summary>
    [Description("F14")]
    KeyF14 = 0x69,

    /// <summary>Keyboard F15.</summary>
    [Description("F15")]
    KeyF15 = 0x6a,

    /// <summary>Keyboard F16.</summary>
    [Description("F16")]
    KeyF16 = 0x6b,

    /// <summary>Keyboard F17.</summary>
    [Description("F17")]
    KeyF17 = 0x6c,

    /// <summary>Keyboard F18.</summary>
    [Description("F18")]
    KeyF18 = 0x6d,

    /// <summary>Keyboard F19.</summary>
    [Description("F19")]
    KeyF19 = 0x6e,

    /// <summary>Keyboard F20.</summary>
    [Description("F20")]
    KeyF20 = 0x6f,

    /// <summary>Keyboard F21.</summary>
    [Description("F21")]
    KeyF21 = 0x70,

    /// <summary>Keyboard F22.</summary>
    [Description("F22")]
    KeyF22 = 0x71,

    /// <summary>Keyboard F23.</summary>
    [Description("F23")]
    KeyF23 = 0x72,

    /// <summary>Keyboard F24.</summary>
    [Description("F24")]
    KeyF24 = 0x73,

    /// <summary>Keyboard Execute.</summary>
    [Description("Execute")]
    KeyOpen = 0x74,

    /// <summary>Keyboard Help.</summary>
    [Description("Help")]
    KeyHelp = 0x75,

    /// <summary>Keyboard Menu.</summary>
    [Description("Menu")]
    KeyMenu = 0x76,

    /// <summary>Keyboard Select.</summary>
    [Description("Select")]
    KeySelect = 0x77,

    /// <summary>Keyboard Stop.</summary>
    [Description("Stop")]
    KeyStop = 0x78,

    /// <summary>Keyboard Again.</summary>
    [Description("Again")]
    KeyAgain = 0x79,

    /// <summary>Keyboard Undo.</summary>
    [Description("Undo")]
    KeyUndo = 0x7a,

    /// <summary>Keyboard Cut.</summary>
    [Description("Cut")]
    KeyCut = 0x7b,

    /// <summary>Keyboard Copy.</summary>
    [Description("Copy")]
    KeyCopy = 0x7c,

    /// <summary>Keyboard Paste.</summary>
    [Description("Paste")]
    KeyPaste = 0x7d,

    /// <summary>Keyboard Find.</summary>
    [Description("Find")]
    KeyFind = 0x7e,

    /// <summary>Keyboard Mute.</summary>
    [Description("Mute")]
    KeyMute = 0x7f,

    /// <summary>Keyboard Volume Up.</summary>
    [Description("VolumeUp")]
    KeyVolumeUp = 0x80,

    /// <summary>Keyboard Volume Down.</summary>
    [Description("VolumeDown")]
    KeyVolumeDown = 0x81,

    /// <summary>Keyboard Locking Caps Lock.</summary>
    [Description("Locking CapsLock")]
    KeyCapsLockLocking = 0x82,

    /// <summary>Keyboard Locking Num Lock.</summary>
    [Description("Locking NumLock")]
    KeyNumLockLocking = 0x83,

    /// <summary>Keyboard Locking Scroll Lock.</summary>
    [Description("Locking ScrollLock")]
    KeyScrollLockLocking = 0x84,

    /// <summary>Keypad Brazilian Comma.</summary>
    [Description("Brazilian Comma")]
    KeyBRComma = 0x85,

    /// <summary>Keyboard Brazilian Equal Sign.</summary>
    [Description("Brazilian EqualSign")]
    KeyBREqual = 0x86,

    /// <summary>Keyboard International1.</summary>
    [Description("Ro")]
    KeyRo = 0x87,

    /// <summary>Keyboard International2.</summary>
    [Description("Katakana Hiragana")]
    KeyKatakanaHiragana = 0x88,

    /// <summary>Keyboard International3.</summary>
    [Description("Yen")]
    KeyYen = 0x89,

    /// <summary>Keyboard International4.</summary>
    [Description("Henken")]
    KeyHenken = 0x8a,

    /// <summary>Keyboard International5.</summary>
    [Description("Muhenkan")]
    KeyMuhenkan = 0x8b,

    /// <summary>Keyboard International6.</summary>
    [Description("Japanese Comma")]
    KeyJPComma = 0x8c,

    /// <summary>Keyboard International7.</summary>
    [Description("International 7")]
    KeyInternational7 = 0x8d,

    /// <summary>Keyboard International8.</summary>
    [Description("International 8")]
    KeyInternational8 = 0x8e,

    /// <summary>Keyboard International9.</summary>
    [Description("International 9")]
    KeyInternational9 = 0x8f,

    /// <summary>Keyboard LANG1.</summary>
    [Description("Hanguel")]
    KeyHanguel = 0x90,

    /// <summary>Keyboard LANG2.</summary>
    [Description("Hanja")]
    KeyHanja = 0x91,

    /// <summary>Keyboard LANG3.</summary>
    [Description("Katakana")]
    KeyKatakana = 0x92,

    /// <summary>Keyboard LANG4.</summary>
    [Description("Hiragana")]
    KeyHiragana = 0x93,

    /// <summary>Keyboard LANG5.</summary>
    [Description("Zenkaku Hankaku")]
    KeyZenkakuHankaku = 0x94,

    /// <summary>Keyboard LANG6.</summary>
    [Description("Language 6")]
    KeyLanguage6 = 0x95,

    /// <summary>Keyboard LANG7.</summary>
    [Description("Language 7")]
    KeyLanguage7 = 0x96,

    /// <summary>Keyboard LANG8.</summary>
    [Description("Language 8")]
    KeyLanguage8 = 0x97,

    /// <summary>Keyboard LANG9.</summary>
    [Description("Language 9")]
    KeyLanguage9 = 0x98,

    /// <summary>Keyboard Alternate Erase.</summary>
    [Description("Alternate Erase")]
    KeyAlternateErase = 0x99,

    /// <summary>Keyboard SysReq/Attention.</summary>
    [Description("System Request")]
    KeySystemRequest = 0x9a,

    /// <summary>Keyboard Cancel.</summary>
    [Description("Cancel")]
    KeyCancel = 0x9b,

    /// <summary>Keyboard Clear.</summary>
    [Description("Clear")]
    KeyClear = 0x9c,

    /// <summary>Keyboard Prior.</summary>
    [Description("Prior")]
    KeyPrior = 0x9d,

    /// <summary>Keyboard Return.</summary>
    [Description("Return")]
    KeyReturn = 0x9e,

    /// <summary>Keyboard Separator.</summary>
    [Description("Seperator")]
    KeySeperator = 0x9f,

    /// <summary>Keyboard Out.</summary>
    [Description("Out")]
    KeyOut = 0xa0,

    /// <summary>Keyboard Oper.</summary>
    [Description("Oper")]
    KeyOper = 0xa1,

    /// <summary>Keyboard Clear/Again.</summary>
    [Description("Clear/Again")]
    KeyClearAgain = 0xa2,

    /// <summary>Keyboard CrSel/Props.</summary>
    [Description("ClearSel/Props")]
    KeyCrSelProps = 0xa3,

    /// <summary>Keyboard ExSel.</summary>
    [Description("ExSel")]
    KeyExSel = 0xa4,

    /// <summary>Keypad 00.</summary>
    [Description("Keypad 00")]
    KeyNP00 = 0xb0,

    /// <summary>Keypad 000.</summary>
    [Description("Keypad 000")]
    KeyNP000 = 0xb1,

    /// <summary>Thousands Separator.</summary>
    [Description("Keypad Thousands Seperator")]
    KeyNPThouSeperator = 0xb2,

    /// <summary>Decimal Separator.</summary>
    [Description("Keypad Decimal Seperator")]
    KeyNPDecSeperator = 0xb3,

    /// <summary>Currency Unit.</summary>
    [Description("Keypad Currency Unit")]
    KeyNPCurrencyUnit = 0xb4,

    /// <summary>Currency Sub-unit.</summary>
    [Description("Keypad Currency Subunit")]
    KeyNPCurrencySubUnit = 0xb5,

    /// <summary>Keypad (.</summary>
    [Description("Keypad (")]
    KeyNPLeftParentheses = 0xb6,

    /// <summary>Keypad ).</summary>
    [Description("Keypad )")]
    KeyNPRightParentheses = 0xb7,

    /// <summary>Keypad {.</summary>
    [Description("Keypad {")]
    KeyNPLeftBrace = 0xb8,

    /// <summary>Keypad }.</summary>
    [Description("Keypad }")]
    KeyNPRightBrace = 0xb9,

    /// <summary>Keypad Tab.</summary>
    [Description("Keypad Tab")]
    KeyNPTab = 0xba,

    /// <summary>Keypad Backspace.</summary>
    [Description("Keypad Backspace")]
    KeyNPBackspace = 0xbb,

    /// <summary>Keypad A.</summary>
    [Description("Keypad A")]
    KeyNPA = 0xbc,

    /// <summary>Keypad B.</summary>
    [Description("Keypad B")]
    KeyNPB = 0xbd,

    /// <summary>Keypad C.</summary>
    [Description("Keypad C")]
    KeyNPC = 0xbe,

    /// <summary>Keypad D.</summary>
    [Description("Keypad D")]
    KeyNPD = 0xbf,

    /// <summary>Keypad E.</summary>
    [Description("Keypad E")]
    KeyNPE = 0xc0,

    /// <summary>Keypad F.</summary>
    [Description("Keypad F")]
    KeyNPF = 0xc1,

    /// <summary>Keypad XOR.</summary>
    [Description("Keypad XOR")]
    KeyNPXOR = 0xc2,

    /// <summary>Keypad ^.</summary>
    [Description("Keypad ^")]
    KeyNPCaret = 0xc3,

    /// <summary>Keypad %.</summary>
    [Description("Keypad %")]
    KeyNPPercent = 0xc4,

    /// <summary>Keypad LessThan.</summary>
    [Description("Keypad <")]
    KeyNPLessThan = 0xc5,

    /// <summary>Keypad GreaterThan.</summary>
    [Description("Keypad >")]
    KeyNPGreaterThan = 0xc6,

    /// <summary>Keypad &.</summary>
    [Description("Keypad &")]
    KeyNPAmpersand = 0xc7,

    /// <summary>Keypad &&.</summary>
    [Description("Keypad &&")]
    KeyNPDoubleAmpersand = 0xc8,

    /// <summary>Keypad |.</summary>
    [Description("Keypad |")]
    KeyNPVerticalBar = 0xc9,

    /// <summary>Keypad ||.</summary>
    [Description("Keypad ||")]
    KeyNPDoubleVerticalBar = 0xca,

    /// <summary>Keypad :.</summary>
    [Description("Keypad :")]
    KeyNPColon = 0xcb,

    /// <summary>Keypad #.</summary>
    [Description("Keypad #")]
    KeyNPPound = 0xcc,

    /// <summary>Keypad Space.</summary>
    [Description("Keypad Space")]
    KeyNPSpace = 0xcd,

    /// <summary>Keypad @.</summary>
    [Description("Keypad @")]
    KeyNPAnd = 0xce,

    /// <summary>Keypad !.</summary>
    [Description("Keypad !")]
    KeyNPExclamation = 0xcf,

    /// <summary>Keypad Memory Store.</summary>
    [Description("Keypad Memory Store")]
    KeyNPMemoryStore = 0xd0,

    /// <summary>Keypad Memory Recall.</summary>
    [Description("Keypad Memory Recall")]
    KeyNPMemoryRecall = 0xd1,

    /// <summary>Keypad Memory Clear.</summary>
    [Description("Keypad Memory Clear")]
    KeyNPMemoryClear = 0xd2,

    /// <summary>Keypad Memory Add.</summary>
    [Description("Keypad Memory Add")]
    KeyNPMemoryAdd = 0xd3,

    /// <summary>Keypad Memory Subtract.</summary>
    [Description("Keypad Memory Subtract")]
    KeyNPMemorySubtract = 0xd4,

    /// <summary>Keypad Memory Multiply.</summary>
    [Description("Keypad Memory Multiply")]
    KeyNPMemoryMultiply = 0xd5,

    /// <summary>Keypad Memory Divide.</summary>
    [Description("Keypad Memory Divide")]
    KeyNPMemoryDivide = 0xd6,

    /// <summary>Keypad +/-.</summary>
    [Description("Keypad +/-")]
    KeyNPKeypadPlusMinus = 0xd7,

    /// <summary>Keypad Clear.</summary>
    [Description("Keypad Clear")]
    KeyNPClear = 0xd8,

    /// <summary>Keypad Clear Entry.</summary>
    [Description("Keypad Clear Entry")]
    KeyNPClearEntry = 0xd9,

    /// <summary>Keypad Binary.</summary>
    [Description("Keypad Binary")]
    KeyNPBinary = 0xda,

    /// <summary>Keypad Octal.</summary>
    [Description("Keypad Octal")]
    KeyNPOctal = 0xdb,

    /// <summary>Keypad Decimal.</summary>
    [Description("Keypad Decimal")]
    KeyNPDecimal = 0xdc,

    /// <summary>Keypad Hexadecimal.</summary>
    [Description("Keypad Hexadecimal")]
    KeyNPHexadecimal = 0xdd,

    /// <summary>Keyboard Left Control.</summary>
    [Description("LeftControl")]
    KeyLeftControl = 0xe0,

    /// <summary>Keyboard Left Shift.</summary>
    [Description("LeftShift")]
    KeyLeftShift = 0xe1,

    /// <summary>Keyboard Left Alt.</summary>
    [Description("LeftAlt")]
    KeyLeftAlt = 0xe2,

    /// <summary>Keyboard Left GUI.</summary>
    [Description("LeftGUI")]
    KeyLeftMeta = 0xe3,

    /// <summary>Keyboard Right Control.</summary>
    [Description("RightControl")]
    KeyRightControl = 0xe4,

    /// <summary>Keyboard Right Shift.</summary>
    [Description("RightShift")]
    KeyRightShift = 0xe5,

    /// <summary>Keyboard Right Alt.</summary>
    [Description("RightAlt")]
    KeyRightAlt = 0xe6,

    /// <summary>Keyboard Right GUI.</summary>
    [Description("RightGUI")]
    KeyRightMeta = 0xe7,

    /// <summary>Keyboard Media Play/Pause.</summary>
    [Description("Media Play/Pause")]
    MediaPlayPause = 0xe8,

    /// <summary>Keyboard Media StopCD.</summary>
    [Description("Media StopCD")]
    MediaStopCD = 0xe9,

    /// <summary>Keyboard Media Previous.</summary>
    [Description("Media Previous")]
    MediaPrevious = 0xea,

    /// <summary>Keyboard Media Next.</summary>
    [Description("Media Next")]
    MediaNext = 0xeb,

    /// <summary>Keyboard Media Eject CD.</summary>
    [Description("Media Eject CD")]
    MediaEjectCD = 0xec,

    /// <summary>Keyboard Media Volume UP.</summary>
    [Description("Media Volume Up")]
    MediaVolumeUp = 0xed,

    /// <summary>Keyboard Media Volume Down.</summary>
    [Description("Media Volume Down")]
    MediaVolumeDown = 0xee,

    /// <summary>Keyboard Media Mute.</summary>
    [Description("Media Mute")]
    MediaMute = 0xef,

    /// <summary>Keyboard Media WWW Web Browser.</summary>
    [Description("Media WWW")]
    MediaWWW = 0xf0,

    /// <summary>Keyboard Media Back.</summary>
    [Description("Media Back")]
    MediaBack = 0xf1,

    /// <summary>Keyboard Media Forward.</summary>
    [Description("Media Forward")]
    MediaForward = 0xf2,

    /// <summary>Keyboard Media Stop.</summary>
    [Description("Media Stop")]
    MediaStop = 0xf3,

    /// <summary>Keyboard Media Find.</summary>
    [Description("Media Find")]
    MediaFind = 0xf4,

    /// <summary>Keyboard Media Scroll Up.</summary>
    [Description("Media ScrollUp")]
    MediaScrollUp = 0xf5,

    /// <summary>Keyboard Media Scroll Down.</summary>
    [Description("Media ScrollDown")]
    MediaScrollDown = 0xf6,

    /// <summary>Keyboard Media Edit.</summary>
    [Description("Media Edit")]
    MediaEdit = 0xf7,

    /// <summary>Keyboard Media Sleep.</summary>
    [Description("Media Sleep")]
    MediaSleep = 0xf8,

    /// <summary>Keyboard Media Coffee.</summary>
    [Description("Media Coffee")]
    MediaCoffee = 0xf9,

    /// <summary>Keyboard Media Refresh.</summary>
    [Description("Media Refresh")]
    MediaRefresh = 0xfa,

    /// <summary>Keyboard Media Calc.</summary>
    [Description("Media Calculator")]
    MediaCalculator = 0xfb,
  }
}