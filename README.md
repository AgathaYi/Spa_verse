# Spa\_verse

## About Project

Spa\_verse는 Unity를 사용하여 제작된 2D 메타버스 공간입니다. 플레이어는 다양한 씬(Scene)에서 캐릭터를 다르게 조작하여 이동, 점프, 장애물 회피 등의 기본 동작을 수행하며 진행합니다.

## 폴더 구조

* **Assets/Scenes**: Unity 씬 파일
* **Assets/Scripts**: C# 스크립트

  * BlueZone: 고드름 피하기 게임 관련 스크립트
  * Control: 공통 및 메인씬 컨트롤러
  * Manager: 중심 매니저 스크립트
  * RedZone: 미활성화 상태
  * UI: BaseUI 상속 UI 스크립트 및 NPC 상호작용 스크립트
* **Assets/Prefabs**: 프리팹(게임오브젝트 템플릿)
* **Assets/Art**: 그래픽 에셋(스프라이트, 텍스처 등)
* **Assets/UI**: UI 요소(캔버스, 버튼 등)
* **README.md**: 프로젝트 소개 및 사용법

## 씬별 설명 및 조작법 및 조작법

### 1. Main Scene (`MainScene`)

* **목적**: 캐릭터의 기본 이동, 회전(플립), 움직임 로직 테스트, 문 열림과 NPC 상호작용
* **조작법**:

  * 이동: `W`, `A`, `S`, `D`
  * 캐릭터 플립(좌우 반전): 마우스 포인터 위치에 따라 자동으로 얼굴 방향이 변함
  * 문 열기: `F`
  * 달리기: 이동키 + `Shift`
  * 버튼 클릭: 왼쪽 마우스 버튼 클릭

### 2. Blue Zone (`BlueZone` 씬)

* **목적**: 고드름 사이 구간을 점프하여 위·아래로 랜덤하게 생성되는 고드름(Icicles)을 피하는 게임. 최대한 멀리 가보세요!
* **조작법**:

  * 점프: `SpaceBar` 또는 왼쪽 마우스 버튼 클릭
* **게임 규칙**:

  * 고드름에 닿으면 캐릭터가 사망하며 Game Over UI가 표시됩니다.
  * Game Over 후 Restart 버튼을 클릭하면 동일 씬에서 리스타트가 가능합니다.

### 3. Red Zone (`RedZone` 씬)

* **현황**: 미개발 상태이며, 현재 동작하지 않습니다.

---

피드백 많이 주시면 정말 감사합니다!ㅎㅎ


___ 스파르타 Unity10기 이선량
