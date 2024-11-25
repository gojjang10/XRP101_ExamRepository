# 6번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### FPS 조작 구현
- 실행 시, 마우스 커서가 비활성화되며 마우스 회전으로 플레이어의 시야가 회전한다.
- 현재 바라보고 있는 방향 기준으로 W, A, S, D로 전, 후, 좌, 우 이동을 수행한다
- 마우스 좌클릭 시, 시야 정면 방향으로 레이를 발사하고 레이캐스트에 검출된 적의 이름을 콘솔에 로그로 출력한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 카메라가 플레이어기준의 화면으로 따라가는 것이 아닌 그냥 가만히 있는 버그 발견 
CameraController스크립트의 _followTarget를 [SerializeField]를 사용해서 제대로 참조가 되는지 확인했지만 같은 결과가 나오기에 SetTransform()함수 속 로직을 일부 변경하여서 구현

- 레이를 쏴도 적이 검출되지 않는 버그 발견
LayerMask를 적용해놨기 때문에 인스펙터창에서 Enemy프리펩들의 레이어를 Enemy로 되어있는지 확인하고, Gun스크립트가 붙어있는 인스펙터에서 LayerMask를 설정해주어 구현