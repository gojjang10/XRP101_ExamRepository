# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
- CubeManager쪽의 Awake함수 속 SetCubePosition() 함수와 Start함수 속 CreateCube() 함수의 위치가 바뀌어야한다.
함수의 내용을 살펴보면 SetCubePosition()함수는 위치를 지정해주고 있고, CreateCube()함수는 큐브를 생성해주는 로직이기때문에, 유니티 라이프사이클에 따라서 Awake에 CreateCube(), Start에 CreateCube()를 넣는것이 옳다.

- SetCubePosition()함수내용을 바꾸어야한다.
_cubeController변수를 사용해서 CubeController 스크립트 속 함수를 사용해서 위치를 지정해주고 있는데 CubeManager에 있는 _cubeSetPoint변수를 사용하지 않고, CubeController 스크립트 속 SetPoint 변수의 프로퍼티를 설정해주고, 올바른 변수로 현재 transform.position을 진행해준다.
