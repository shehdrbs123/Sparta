# 내일배움캠프 3회차 2D 유니티 프로젝트 개인과제



[유튜브 동영상 링크](https://www.youtube.com/watch?v=RTNzJ8vCGZE)

## 개요

개발 환경 : c#, Unity 2022.3.8f1, Rider 2023.1.2 <br>
개발 내용 :
- 맵 제작기 개발
- 캐릭터 이동, 무기 방향
- 캐릭터 애니메이션 구현
- 투사체 발사 및 충돌처리 조정
- 캐릭터 변경, 캐릭터 이름 변경
- 카메라 세팅
- 미니맵 구현

## 클래스 다이어그램
### 시스템 부분
![이미지](./readmeImage/시스템%20부분%20UML.png)

### 맵 제작 부분
![이미지](./readmeImage/맵%20제작기%20UML.png)

### 입력 부분
![이미지](./readmeImage/입력부분%20UML%20완성.png)

<br><br><br>

## 구현 방향
- 유니티의 여러 시스템을 최대한 활용해보기
  - ScriptableObject, EditorScript, RenderTexture, Resources

<br>


- 유니티 게임오브젝트 외 c# 클래스를 최대한 활용해보기
  - ObjectPool 제네릭 클래스 직접 제작

<br><br><br>

## 구현 구조 및 결과
각 클래스별 역할<br>

### 맵 제작기
|클래스 이름|역할|
|---|---|
|[MapTool](./Assets/Practice/Scripts/MapGen/MapTool.cs)|GameObject에 배치시키고, MapTheme의 내용에 따라 절차적으로 맵을 그려주는 모듈|
|[MapTheme](./Assets/Practice/Scripts/MapGen/MapTheme.cs)|ScriptableObject로 MapTool에서 사용될 Tileset을 지정해주는 Asset |
|[MapToolEditorScript](./Assets/Practice/Scripts/MapGen/Editor/MapToolEditorScript.cs)|MapTool의 Inspector를 일부 수정, 맵 생성/Theme Reload 버튼을 추가하고<br>버튼에 맞춰 기능을 수행|

<br>

### 공통부분
|클래스 이름|역할|
|---|---|
|[ClassGetter](./Assets/Practice/Scripts/Common/ClassGetter.cs)|C# Class나 Resources 내의 Prefabs을 메모리에 로드하고 사용할 수 있도록 도와주는 모듈|


<br>

### Manager
|클래스 이름|역할|
|---|---|
|[GameManager](./Assets/Practice/Scripts/Managers/GameManager.cs)|게임에서의 모든 매니저를 보유하고, 게임과 시작과 끝을 관리하는 모듈|
|[GameDataManager](./Assets/Practice/Scripts/Managers/GameDataManager.cs)|게임 내의 인스턴스의 데이터들을 모아놓은 부분으로 저장 기능을 사용하기 위해 만든 모듈|
|[IDataReader](./Assets/Practice/Scripts/Managers/IDataReader.cs)|외부의 텍스트 데이터를 읽어주는 기능을 가진 모듈<br>추상 클래스로 데이터를 읽어 string[]로 반환해주는 기능을 가지고 있음|
|[UIManager](./Assets/Practice/Scripts/Managers/UIManager.cs)|Prefab으로 된 UI를 오브젝트 풀 형태로 보유하고 제공하는 모듈<br> 재사용이 가능한 모듈을 보유함으로 써 어디서든 해당 UI를 사용 가능|
|[ObjectPool](./Assets/Practice/Scripts/Managers/ObjectPool.cs)|각종 컨테이너에서 사용되던 ObjectPool 기능을 제네릭화 하여 만든 클래스|

<br><br>

### UI
|클래스 이름|역할
|---|---|
|[BaseUI](./Assets/Practice/Scripts/UI/BaseUI.cs)|모든 UI script의 부모로, 공통된 기능메소드 보유하여 중복코드을 방지하는 모듈|
|[ChangeCharaterUI](./Assets/Practice/Scripts/UI/ChangeCharaterUI.cs)|캐릭터를 변경할 때 UI내 버튼 기능과 변경할 데이터를 들고 있는 모듈|
|[TopUI](./Assets/Practice/Scripts/UI/TopUI.cs)|인게임 상황에서의 버튼 기능(캐릭터바꾸기,이름변경)을 가지고 UIManager로 부터 불러와 시현해주는 모듈
|[NameUI](./Assets/Practice/Scripts/UI/NameUI.cs)|캐릭터의 이름을 변경할 때 사용하는 UI의 기능을 보유한 모듈|

<br><br>


### Player 입력
이 부분은 강의에서의 내용을 80%정도 비슷하게 구현<br>
옵져버 패턴으로 구성되어있음.

|클래스 이름|역할|
|---|---|
|[TopDownCharacterController1](./Assets/Practice/Scripts/TopDownCharacterController1.cs)|어떤 입력을 받을지에 대한 내용을 델리게이트로 보유/실행해주는 클래스, 구현 클래스에서 델리게이트를 구독해 실행명령을 기다리고 있는다.|
|[PlayerInputController1](./Assets/Practice/Scripts/PlayerInputController1.cs)|PlayerInput에서 설정된 입력을 받아와 TopDownCharacterController로 전달하는 역할을 하는 모듈|
|[PlayerMovement1](./Assets/Practice/Scripts/Entity/PlayerAimRotation1.cs)|Player의 움직임을 구현하는 모듈|
|[PlayerAimRotation1](./Assets/Practice/Scripts/Entity/PlayerAimRotation1.cs)|마우스의 움직임에 따라 캐릭터의 방향, 무기의 방향을 설정해주는 모듈<br> |
|[PlayerShooting1](./Assets/Practice/Scripts/Entity/PlayerShooting)|Player의 마우스 방향,마우스버튼에 따라 화살을 생성해주는 모듈|
|[PlayerAnimatorActivator](./Assets/Practice/Scripts/Entity/PlayerAnimatorActivator.cs)|Player의 velocity로 부터 움직임을 감지해 애니메이터를 작동 시켜주는 모듈|

<br><br>

### GameObject 관련
|클래스 이름|역할|
|---|---|
|[Actor](./Assets/Practice/scripts/Actor.cs)|게임에서 저장이 필요한 오브젝트에 부착되어 GameDataManager에 구독등록해주는 모듈 <br>그외에도 식별자(이름)을 보유하는 기능을 가진다.|
|[Player](./Assets/Practice/scripts/Player.cs)|게임에서 조작을 당하는 오브젝트에 부착되어 사용되는 오브젝트, 캐릭터의 데이터 변경, 내부컴포넌트의 작동상태 조정 등의에서 사용됨|
|[PlayerCheck](./Assets/Practice/scripts/PlayerCheck.cs)|인게임 씬에 들어왔을 때 플레이어를 체크하고, 없다면 생성, 있다면 startpointer로 이동시켜준다|
|[CameraAttacher](./Assets/Practice/scripts/Actor.cs)|Player를 찾아 카메라를 플레이어의 위치로 연결해주는 모듈|
|[Arrow](./Assets/Practice/scripts/Actor.cs)|생성 시 화살의 속도(속성)에 따라 자동으로 날아게 만든 모듈, 충돌 처리도 되어있음|

<br>

### 생성된 Prefabs과 ScriptableObject

|이름|역할|
|---|---|
|MapTool|Map을 만들기 위해 설정한 게임오브젝트를 가지고 있는 Prefab|
|Arrow|화살의 기본정보를 저장하고 있는 Prefab|
|ChangeCharacterUI|캐릭터 변경을 위해 준비된 UI|
|NameUI|캐릭터의 이름 변경을 위해 준비된 UI|
|Player|플레이어에 대한 기본 저장 정보를 가지고 있는 모듈



## 반성

### 전체적인 설계의 오류
![이미지](./readmeImage/내배캠%202d개인프로젝트.png)
해당 이미지는 간략하게 UML을 구성해본 결과이다. 현재의 UML과는 다르다
- C#으로 프로젝트를 진행했던 버릇이 남아있던 걸까, 설계를 하면서 게임오브젝트에 대해서 신경을 쓰지 못했다. 그러다보니 설계와 구현에서의 괴리가 발생해서 상당 부분 수정을 가했다.<br> 실제로 Prefabs의 활용을 생각을 못했어서 ObjectPool의 설계에서 게임오브젝트의 고려가 되지 않았어서 코딩중에 추가되었던 부분이 있었다.

다음 유니티 과제에서는 GameObject, Prefabs, Scriptable Object등을 모두 고려할 수 있는 설계를 더 고민해봐야겠다.
<br> 욕심이지만 Monobehaviour 클래스를 덜 쓰고 c# 클래스를 더 활용할 수 있는 방안을 찾았으면 좋겠다. 아무래도, Monobehaviour를 사용함으로써 추가되는 비용을 줄일 수 있으니 말이다.
  
 






