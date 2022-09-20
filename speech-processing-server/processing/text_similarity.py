def ts(sentence):
    
    from sklearn.feature_extraction.text import TfidfVectorizer

    # 객체 생성
    tfidf_vectorizer = TfidfVectorizer()
    # 문장 벡터화 진행
    tfidf_matrix = tfidf_vectorizer.fit_transform(sentence)
    # 각 단어
    text = tfidf_vectorizer.get_feature_names()
    # 각 단어의 벡터 값
    idf = tfidf_vectorizer.idf_



    from sklearn.metrics.pairwise import cosine_similarity
    cs = cosine_similarity(tfidf_matrix[0:1], tfidf_matrix[1:2])
    print('코사인 유사도: ', cs) # -1 ~ 1 


    # 유사하다고 판단(특정 기준 만족)될 시에 T/F를 반환해야하나 값이 어떻게 나올지 모르기에 제외.
    from sklearn.metrics.pairwise import euclidean_distances
    ed = euclidean_distances(tfidf_matrix[0:1], tfidf_matrix[1:2])
     # 거리를 측정. 정규화하지 않았으므로 값이 1보다 커질 수 있음.
    print('유클리디언 유사도: ', ed)


    import numpy as np
    def l1_normalize(v):
        norm = np.sum(v)
        return v / norm
    tfidf_norm_l1 = l1_normalize(tfidf_matrix)
    ned = euclidean_distances(tfidf_norm_l1[0:1], tfidf_norm_l1[1:2])
    print('정규화 + 유클리디언 유사도: ', ned)


    # import numpy as np
    def l1_normalize(v):
        norm = np.sum(v)
        return v / norm 
    # L1 정규화  
    tfidf_norm_l1 = l1_normalize(tfidf_matrix)
    # 맨하탄 유사도
    from sklearn.metrics.pairwise import manhattan_distances
    md = manhattan_distances(tfidf_norm_l1[0:1], tfidf_norm_l1[1:2])
    print('정규화 + 맨하탄 유사도: ', md) # 0 ~ 1


    # 적합한 유사도 알고리즘 선택할 것. 정규화를 거친 ned, md 중에 하나를 선택하는 것이 좋아보임
    return cs # ed, ned, md