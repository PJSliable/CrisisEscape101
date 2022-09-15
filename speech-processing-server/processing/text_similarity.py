def text_similarity(sentence):
    
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
    print('코사인 유사도: ', cs)


    from sklearn.metrics.pairwise import euclidean_distances
    ed = euclidean_distances(tfidf_matrix[0:1], tfidf_matrix[1:2])
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
    print('정규화 + 맨하탄 유사도: ', md)