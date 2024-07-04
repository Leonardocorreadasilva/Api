using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<ReviewEntity> _reviewRepository;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<ProductEntity> _productRepository;

        public ReviewService(IRepository<ReviewEntity> reviewRepository, 
            IRepository<UserEntity> userRepository, 
            IRepository<ProductEntity> productRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _reviewRepository.DeleteAsync(id);
        }

        public async Task<ReviewEntity> Get(Guid id)
        {
            return await _reviewRepository.SelectAsync(id);
        }

        public async Task<IEnumerable<ReviewEntity>> GetAll()
        {
            return await _reviewRepository.SelectAsync();
        }

        public async Task<ReviewEntity> Post(ReviewRequest review)
        {
            // Busca o usuário e o produto pelos IDs fornecidos
            var user = await _userRepository.SelectAsync(review.UserReviewId);
            var product = await _productRepository.SelectAsync(review.ProductReviewId);

            // Verifica se o usuário e o produto existem
            if (user == null || product == null)
            {
                throw new KeyNotFoundException("Usuário ou Produto não encontrado.");
            }

            // Converte ReviewRequest para ReviewEntity
            var reviewEntity = new ReviewEntity
            {

                UserReview = user,
                ProductReview = product,
                Rating = review.Rating,
                Coments = review.Coments,
                Reviews = review.Reviews
            };

            return await _reviewRepository.InsertAsync(reviewEntity);
        }

        public async Task<ReviewEntity> Put(ReviewRequest review)
        {
            // Primeiro, obtenha a entidade existente
            var existingReview = await _reviewRepository.SelectAsync(review.Id);
            if (existingReview == null)
            {
                throw new KeyNotFoundException("Review não encontrada.");
            }

            // Busca o usuário e o produto pelos IDs fornecidos
            var user = await _userRepository.SelectAsync(review.UserReviewId);
            var product = await _productRepository.SelectAsync(review.ProductReviewId);

            // Verifica se o usuário e o produto existem
            if (user == null || product == null)
            {
                throw new KeyNotFoundException("Usuário ou Produto não encontrado.");
            }

            // Atualiza a entidade existente com os novos valores
            existingReview.UserReview = user;
            existingReview.ProductReview = product;
            existingReview.Rating = review.Rating;
            existingReview.Coments = review.Coments;
            existingReview.Reviews = review.Reviews;

            return await _reviewRepository.UpdateAsync(existingReview);
        }
    }
}
