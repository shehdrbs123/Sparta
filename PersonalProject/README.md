# SpartaDungoen

## 구현 방향
- Data Driven System을 최대한 반영해서 프로그래밍 하는 것
- 여러 환경의 언어를 지원하는 것을 가정, string 파일을 기준으로 출력하도록 설계
- 각 기능을 추가하는 데 어려움이 없도록 제작


## 구현 결과 및 반성

- Data읽어오는 부분
  - DataReader의 부모 클래스를 생성, String.Split() 함수를 이용해 한줄씩 읽고, 구분하는 역할
  - Process의 오버라이딩을 통해서 각 데이터에 맞는 클래스로 가공, 데이터 컨테이너에 장입

<br>

- Data관리
  - DataReader를 통해 읽어온 데이터를 Container라는 개념으로 사용되는 모든 데이터를 보관
  - 각 데이터 별로 클래스,Container클래스가 존재
  - ResourceManager를 통해 초기화, 데이터 로드를 수행함
  - Container에 들어있는 데이터는 Dictionary 클래스로 저장되어, string을 통한 접근 수행

<br>

- Data기준
  - \Data\String\StringData_KR.txt에서 NameID를 이용
  - Dictionary에 key로 사용됨
  - 다른 데이터(행동 정보, 던전 리스트, 상점 리스트)는 이 NameID를 이용해 제작

<br>


- test
  - Command 클래스를 이용한 상속을 통해 화면기능의 추상화/일반화 성공
    - 새로운 기능을 추가하는데 큰 수정이 없음
    - 기능 클래스의 이름을 통해 던전리스트의 데이터설정

<br>

- 출력부

 