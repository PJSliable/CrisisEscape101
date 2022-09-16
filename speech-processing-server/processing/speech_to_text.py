# 신규 고객에게는 Speech-to-Text에 사용할 수 있는 $300의 무료 크레딧이 제공됩니다. 
# 모든 고객은 매월 60분의 무료 오디오 스크립트 작성 및 분석을 사용할 수 있으며, 크레딧이 차감되지 않습니다.

# 음성 인식(데이터 로깅 제외 - 기본 구성)
# 표준 모델: $0.006/15초** - 무료 크레딧으로 12500시간 사용 가능
# 고급 모델: $0.009/15초** - 무료 크레딧으로 8333시간 20분 사용 가능
# ** 각 요청은 15초 단위로 올림됩니다.

#!/usr/bin/env python

# Copyright 2016 Google Inc. All Rights Reserved.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

#!/usr/bin/env python

# Copyright 2016 Google Inc. All Rights Reserved.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.


def stt(audiofile):
    # [START speech_quickstart]
    import io
    import os

    # Imports the Google Cloud client library
    # [START migration_import]
    from google.cloud import speech
    # [END migration_import]

    # Instantiates a client
    # [START migration_client]
    client = speech.SpeechClient()
    # [END migration_client]

    # 아직 input 값이 없기 때문에 실행값이 보이지 않음
    audio = audiofile
    config = speech.RecognitionConfig(
        encoding=speech.RecognitionConfig.AudioEncoding.LINEAR16,
        sample_rate_hertz=16000,
        language_code='ko-KR')

    # Detects speech in the audio file
    response = client.recognize(config=config, audio=audio)

    for result in response.results:
        stt_text = result.alternatives[0].transcript
        print('Transcript: {}'.format(result.alternatives[0].transcript))

    return stt_text

if __name__ == '__main__':
    stt()