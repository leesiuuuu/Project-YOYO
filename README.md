# Push&Pull


### 조원


**개발**: 정성찬, 박현민, 이시우, 장경훈

**디자인**: 이시우

---

## 목차


**1.게임설명**

1-1.장르

1-2.시점

1-3.플레이 방식

1-4.클리어 방법 및 목표

1-5.사용 엔진 및 플랫폼

1-6.스테이지

**2.게임 컨텐츠**

2-1.메인 컨텐츠

2-2.서브 컨텐츠

2-2.엔딩

**3.기능**

3-1.능력

## 1.게임 설명

---

### 1-1.장르

---

멀티,협동, 캐쥬얼 게임

### 1-2.시점

---

횡스크롤 사이드뷰

### 1-3.플레이 방식

---

조작법:키보드, 콘솔

멀티 방식: 한 pc에서 두명의 사용자가 동시에 플레이

키보드로 하면 WASD와 화살표, 콘솔은 각자 한개씩

### 1-4.클리어 방법 및 목표

---

**클리어 방법** : 서로 협동하여 열쇠를 모두 획득 후 해당 스테이지의 문에 도착하면 클리어

**목표** : 모든 스테이지 클리어

### 1-5.사용 엔진 및 플랫폼

---

엔진:UnityEngine

엔진 버전:2022.3.21f1

플랫폼: 윈도우

### 1-6.스테이지

---

총 6개의 맵이 존재한다.

> 튜토리얼 맵 하나, 기본 맵 5개

- 1스테이지

![image](https://github.com/user-attachments/assets/50d3dc59-df93-424d-9db6-deaf8cb42e80)

- 2스테이지

![image](https://github.com/user-attachments/assets/d6b34995-be6b-41bc-9a56-e2e008310e3f)

- 3스테이지

![image](https://github.com/user-attachments/assets/2d00d39f-7f2e-4dd2-94cd-2529d175b1f0)

- 4스테이지

![image](https://github.com/user-attachments/assets/36d8bd3e-da47-4110-a93f-62cdb3781393)


- 5스테이지
![image](https://github.com/user-attachments/assets/979363a9-b5f4-4dba-a33d-316045d4d1b7)


## 2.게임 컨텐츠


## 2-1.메인 컨텐츠


스테이지마다 바뀌는 능력을 활용하여, 다른 플레이어와의 협동을 통해 해당 스테이지의 함정등을 파회하며 모든 스테이지를 클리어한다

## 2-2.서브 컨텐츠


팀킬이 가능할만한 요소 추가

## 2-3.엔딩


모든 스테이지 클리어 이후 엔딩크래딧

# 3.기능



## 3-1.능력


**밀치는 장갑**:**일정 게이지를 차징 이후 차징된 양에 따라 다른 플레이어를 밀친다**

이런 느낌으로 초록색 위치일때 가장 큰 파워로 밀치게 된다

![화면 녹화 중 2025-03-26 101937](https://github.com/user-attachments/assets/ec39ed69-9181-4a55-8c49-6117cab06afd)

**끌어오는 장갑: 일정 키를 누를시 그랩 방향이 위아래로 움직인다**

![화면 녹화 중 2025-03-26 102623](https://github.com/user-attachments/assets/aacf6cf1-3b03-4c79-8a5d-e61f84119ef4)

사거리가 점점 늘어나고 일정 길이에 도달하면 약 0.1초간 유지되다 취소된다

0.1초 뒤 취소되는건 가장 먼 사거리일때 타이밍을 잡는 재미요소를 위함

# 스테이지 기믹


**색상 반전**

특정 오브젝트와 상호작용 시 색상 반전

<img width="74" alt="321" src="https://github.com/user-attachments/assets/387012f3-74a7-4e9e-a07d-99f58bc00187" />

위 오브젝트에 닿을시에 색상이 반전 됨

색상 반전을 할 시엔 밟을 수 있는 타일이 달라짐

**주요 오브젝트**

특정 오브젝트를 가지고 맵을 클리어함

ex)

1. 상자를 가져와 발판으로 사용해야하는 상황,
2. 버튼을 눌러야 진행 할 수 있는 상황

**나눠놓기**

각 플레이어들을 다른 위치에 두기

- 플레이어를 나눔으로써 각자의 위치에서 할 일을 해야함

- 퍼즐 요소에 사용

### 사용 리소스 출처

https://assetstore.unity.com/packages/audio/music/8bit-music-album-051321-196147?srsltid=AfmBOorUaI9I9A3xIVTbJrYxmE4YKiXcARvwuUVgmaYW7bfbbCA8MfEC

https://assetstore.unity.com/packages/audio/music/8bit-music-062022-225623

https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116?srsltid=AfmBOopJ7WwyLVu7pqzrAfKBiJYI2TC9F8KAzT2ko1LZ553kCIdCbzqX

https://www.kenney.nl/assets/ui-audio
