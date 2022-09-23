FROM python:3.10.7
WORKDIR /var/jenkins_home/workspace/S07P22A101/speech-processing-server
COPY requirements.txt ./

RUN pip install --upgrade pip
RUN pip install -r requirements.txt
COPY . .
CMD ["gunicorn", "config.wsgi", "--bind", "0.0.0.0:8080"]